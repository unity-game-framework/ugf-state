# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0-preview.1](https://github.com/unity-game-framework/ugf-state/releases/tag/1.0.0-preview.1) - 2024-03-25  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-state/milestone/2?closed=1)  
    

### Added

- Add state switch component ([#3](https://github.com/unity-game-framework/ugf-state/issues/3))  
    - Update dependencies: `com.ugf.editortools` to `3.0.0-preview.4` version.
    - Add `StateGroupComponent<T>` and `StateSelectComponent<T>` classes as generic implementation of group and select states.
    - Add `IStateSelect` interface to define general methods of _Select_ state.
    - Add `StateSwitchComponent` class as state component with switch state logic.

## [1.0.0-preview](https://github.com/unity-game-framework/ugf-state/releases/tag/1.0.0-preview) - 2023-11-21  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-state/milestone/1?closed=1)  
    

### Added

- Add implementation ([#1](https://github.com/unity-game-framework/ugf-state/issues/1))  
    - Add `StateComponent` abstract class as base _State_ implementation for components.
    - Add `StateGroupComponent` class as component group of states.
    - Add `StateSelectComponent` class as component group with state select methods.


