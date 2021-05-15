# <img src="/docs/images/pipeline_icon.png" height="40px"> Pipelines for C#

A library for implementing programs as Pipeline objects. Inspired by Arlo Belshee's talk, [Refactoring to Async](https://www.ustream.tv/recorded/114862163).

[![NuGet Status](https://img.shields.io/nuget/v/Refactoring.Pipelines.svg?style=flat)](https://www.nuget.org/packages/Refactoring.Pipelines/)

<!-- toc -->
## Contents

  * [Pipelines](#pipelines)
  * [Refactoring To Async](#refactoring-to-async)
  * [Available on NuGet](#available-on-nuget)
  * [Suggested VSCode Plugin](#suggested-vscode-plugin)
  * [Attribution](#attribution)<!-- endToc -->


## Pipelines

Pipelines are a mechanism of separating a function that produces something into two things: 
    - an object that represents the process of that function (the "pipeline") 
    - executing that pipeline to produce the result

The advantage of doing this is that the pipeline is easy to test, easy to visualize, and easy to modify globally such as adding logging or converting to async.

This library also allows for simple, small-step transformations to incrementally refactor existing procedural code, making it practical to do in your current production code.

[Read about pipelines here](docs/Pipelines.md)


[Details about actions here](docs/PipelineActions.md)

## Refactoring To Async

[Tutorial Here](docs/RefactoringTutorial.md#top)

## Available on NuGet

 * [Install-Package Refactoring.Pipelines.Approvals](http://nuget.org/packages/Refactoring.Pipelines.Approvals)
 * [Install-Package Refactoring.Pipelines.DotGraph](http://nuget.org/packages/Refactoring.Pipelines.DotGraph)
 * [Install-Package Refactoring.Pipelines](http://nuget.org/packages/Refactoring.Pipelines)

## Suggested VSCode Plugin
 
[Graphviz (dot) language support for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=joaompinto.vscode-graphviz) by João Pinto is great. CTRL-SHIFT-V to preview a `.dot` file as a rendered graph.

## Attribution

[pipeline icon](https://thenounproject.com/term/pipeline/2508171/) by [Francisco Javier Diaz Montejano](https://thenounproject.com/pac0diaz/) from [the Noun Project](https://thenounproject.com/)
