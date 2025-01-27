# README datalayer.client.light

This simple python sample reads values from ctrlX Data Layer.

## Introduction

The sample demonstrates how to read values from ctrlX Data Layer tree and write out the values to console. A subscription is used to get values by data change event in a deterministic publish interval. The single read is performed every 10 seconds in an endless loop.

## Prerequisites for Developing python Apps

* Linux Ubuntu 18.4 (or Windows PC running with Windows Subsystem for Linux (WSL) or a Virtual Box VM)
* Python3 is installed 
* ctrlX AUTOMATION SDK Version 1.8 is installed (extracted and copied to the Ubuntu users home directory)

## Getting Started

As Integrated Development Environment (IDE) we recommend Visual Studio Code.
Therefor the folder .vscode contains configuration files.

### Install Virtual Environment

We recommend to create and activate a virtual environment. Start a terminal in the project directory (workspaceFolder) and enter:

    virtualenv -p python3 venv
    source venv/bin/activate

### Install Wheels

Install the required packages:

    pip3 install -r requirements.txt
    pip3 install ../../whl/ctrlx_datalayer*
    pip3 install ../../whl/ctrlx_fbs-*

### Start IDE

Start your IDE, open main.py and start the program.

## Build an AMD64 Snap

Check your snapcraft version with the command:

    snapcraft --version

For cleaning and building snaps see according chapter.

### Version 2.43

To clean the previous snap build results use:

    snapcraft clean

Build the snap with:

    snapcraft

### Version 4.x or higher

To clean the previous snap build results use:

    snapcraft clean --destructive-mode

Build the snap with:

    snapcraft --destructive-mode

__Important:__  To build an ARM64 (AARCH64) snap use a native ARM64 computer or a virtual machine emulating the ARM64 CPU e.g. with QEMU.


### Install the Snap on the ctrlX

* Open the ctrlX CORE Home page, select Settings - Apps, click on 'Service mode' and confirm.
* Click on the Settings icon and select 'Allow installation from unknown source'
* Select tab 'Local storage', click the + icon, upload and install the snap.
* Switch to Operation mode

## Troubleshooting

* If your snap doesn't work well start a shell on the ctrlX and check the trace regarding your snap: `$ sudo snap logs -f rexroth-python-client`
* Ensure the alldataprovider snap is installed and running.

## Support

If you've any questions visit the [ctrlX AUTOMATION Communitiy](https://developer.community.boschrexroth.com/)

___

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
