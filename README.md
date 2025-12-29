# DragonCatch

DragonCatch is a Unity-made game project developed in the `Terrains` repository. This repository contains the full Unity project including scenes, assets, scripts, and project settings.

## About
DragonCatch is an action/adventure prototype (game) built with Unity. The project includes character assets, audio, environment prefabs, and gameplay scripts.

## Unity version
- Recommended Unity Editor: 2020.3 LTS or later (project was developed with a compatible Unity 2020 or 2021 build). If you open the project in a different major Unity version, the editor may prompt to upgrade project assets.

## How to open
1. Install Unity Hub and the recommended Unity Editor version.
2. Open Unity Hub, click "Add", then select the project folder:
   `C:\Unit training\Terrains` (or wherever you cloned the repo).
3. Open the project in the Unity Editor. Allow the editor to import assets and compile scripts.

## How to run in the Editor
- Open the `Scenes` folder in the Project window and double-click the main scene (for example `MainScene` or similar).
- Press the Play button in the Unity Editor to run the game.

## Build instructions
To create a standalone build:
1. In Unity: File -> Build Settings.
2. Select target platform (Windows/Mac/Linux), add the desired scenes, configure player settings.
3. Click Build and choose an output folder.

## Git and large assets
This repository uses Git LFS (Large File Storage) for large binary assets (audio, textures, models). If you clone the repo, make sure Git LFS is installed locally so large files are downloaded correctly.

- Install Git LFS: https://git-lfs.github.com/
- After installing, run in your shell:

  git lfs install

If you see missing assets after clone, run `git lfs pull` inside the repository.

## Project layout (important folders)
- `Assets/` - Unity assets: scenes, prefabs, audio, models, scripts.
- `ProjectSettings/` - Unity project settings required to open the project with the same configuration.
- `Library/` and `Temp/` are ignored by git and not included in the repository.

## Contributing
If you want to contribute:
1. Create an issue or fork the repository.
2. Make changes on a new branch and open a pull request.
3. Keep commits focused and write clear commit messages.

## License
Specify the license for the project here (if any). For example:

This project is provided under the MIT License. See `LICENSE` file for details.

---

If you'd like, I can:
- Add screenshots or a short gameplay GIF to the README.
- Add badges (build, license) or a Contributor section.
- Customize Unity version precisely if you tell me which Unity version you used.

Tell me if you want any changes or extra sections (screenshots, play instructions, controls, credits).