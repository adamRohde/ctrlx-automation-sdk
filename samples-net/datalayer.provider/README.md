# README .NET datalayer.provider

This .NET sample provides some registered nodes to the ctrlX Data Layer tree. 

__IMPORTANT__:

The sample creates and registers all nodes individually, which is recommended for _small_ to _medium_ sized set of nodes to handle. If you're dealing with a _large_ set of nodes (big data provider) or any _dynamic node hierarchy_, we recommend to use a _virtual provider_ approach, listening just to any _wildcarded address_ ( e.g. myRoot/**) and using _self-managed virtual nodes_, just returned in _OnBrowse()_ method, which is more efficient.

Please read the _Best Practise_ section in common .NET documentation for more details and recommended samples.

## Introduction

The sample demonstrates how to provide nodes to ctrlX Data Layer tree. 
The provider creates nodes with types of int/double/string. 
Also a complex type encoded by [FlatBuffers](https://google.github.io/flatbuffers/) is provided.

## Description

The following code shows the main method with inline documentation:

[Program.cs](https://github.com/boschrexroth/ctrlx-automation-sdk/blob/develop/samples-net/datalayer.provider/Program.cs)

The class ReadOnlyNodeHandler implements the callback methods for read-only support:

[ReadOnlyNodeHandler.cs](https://github.com/boschrexroth/ctrlx-automation-sdk/blob/develop/samples-net/datalayer.provider/ReadOnlyNodeHandler.cs)

The class ReadWriteNodeHandler implements the callback methods for read-write support:

[ReadWriteNodeHandler.cs](https://github.com/boschrexroth/ctrlx-automation-sdk/blob/develop/samples-net/datalayer.provider/ReadWriteNodeHandler.cs)

The class MetadataProvider create the metadata for the registered flatbuffers type and provides it as a singleton:

[MetadataProvider.cs](https://github.com/boschrexroth/ctrlx-automation-sdk/blob/develop/samples-net/datalayer.provider/MetadataProvider.cs.cs)

## Prerequisites

Please read the common .NET docs [here](./../README.md), first.

## Getting Started

1. Launch VSCode
2. Click on the __Remote Explorer__ from the menu.
3. Choose __Open Folder in WSL__.
4. Open the directory __datalayer.provider__.
5. Build and install snap as described [here](./../README.md).
6. Checkout ctrlX Data Layer web frontend (System | Data Layer) 
7. Check the output using __Diagnostics__:

   - Login into your ctrlX
   - Navigate to __Diagnostics -> Logbook__
   - Click __Settings__ on the right top corner
   - Enable __Show system messages__
   - Navigate to __Filter -> Units__ and check your __snap.ctrlx-dotnet-datalayer-provider.app.service__
   - Now you should the see the app output diagnostics.
   - Press __Refresh__ to update.

8. If you have root permissions, you can also watch the output on any ssh console with the command:
   ```bash
   sudo snap logs ctrlx-dotnet-datalayer-provider.app -f | more
   
## Screenshot

![crtrX Data Layer tree](./docs/images/datalayer.provider/datalayer.provider.png)

## Install the App

Login into ctrlX and install the App (Apps).

## Gratulations - We're finished - Let's start coding!


## Support
### Developer Community

Please join the [Developer Community](https://developer.community.boschrexroth.com/) 

### SDK Forum

Please visit the [SDK Forum](https://developer.community.boschrexroth.com/t5/ctrlX-AUTOMATION/ct-p/dcdev_community-bunit-dcae/) 

### Issues

If you've found an error in these sample, please [file an issue](https://github.com/boschrexroth)

## License

MIT License

Copyright (c) 2021 Bosch Rexroth AG

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
