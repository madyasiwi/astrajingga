import os

import yaml

from invoke import task
from invoke.context import Context
from invoke.exceptions import Exit

from pygit2 import discover_repository, Repository


def _get_editor_version(project_path):
    """
    Return Unity editor version of current Unity project
    """
    version_info_file = os.path.join(project_path, 'ProjectSettings', 'ProjectVersion.txt')
    if os.path.isfile(version_info_file):
        with open(version_info_file, "r") as fd:
            project_version = yaml.safe_load(fd)
            return project_version["m_EditorVersion"]
    return ""


@task(aliases=["open"])
def open_project(context_):
    """
    Open project in Unity editor.
    """
    context: Context = context_
    project_repo = Repository(discover_repository(os.getcwd()))
    editor_version = _get_editor_version(project_repo.workdir)
    if not editor_version:
        raise Exit("Not a Unity project path", 1)
    editor_path = f"C:\\Program Files\\Unity\\Hub\\Editor\\{editor_version}\\Editor\\Unity.exe"
    if not os.path.isfile(editor_path):
        raise Exit(f"Unity editor version {editor_version} is not installed.", 2)
    args: list[str] = [
        f'"{editor_path}"',
        "-projectPath", project_repo.workdir
    ]
    context.run(" ".join(args))


@task(aliases=["test"])
def test_project(context_):
    """
    Run Unity tests in batch mode.
    """
    context: Context = context_
    project_repo = Repository(discover_repository(os.getcwd()))
    editor_version = _get_editor_version(project_repo.workdir)
    if not editor_version:
        raise Exit("Not a Unity project path", 1)
    editor_path = f"C:\\Program Files\\Unity\\Hub\\Editor\\{editor_version}\\Editor\\Unity.exe"
    if not os.path.isfile(editor_path):
        raise Exit(f"Unity editor version {editor_version} is not installed.", 2)
    args: list[str] = [
        f'"{editor_path}"',
        "-projectPath", project_repo.workdir,
        "-batchmode",
        "-nographics",
        "-executeMethod madyasiwi.astrajingga.build.CI.RunTests",
        "-quit"
    ]
    context.run(" ".join(args))
