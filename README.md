# What is it?
This repository contains very basic and quite simple implementation of PostScript language interpreter.

Created back in 2013 (February 6 - February 13) just for fun.

# Usage
Build in Visual Studio (tested in VS 2012, should compile in any version above as well).

Run it like
```
PreScript.exe <path-to-ps-or-eps-file>
```

It will result in file 1.bmp containing the output or in a failure in case some unsupported operator is found or file does not exsist.

In case the passed document is a multipage document then files named 1.bmp, 2.bmp, ... will be created.


Some sample ps/eps scripts exist in /SampleScripts directory.

Some interesting examples are:
* gameoflife.ps
* 3compBrunC.eps
* 3compBrunD.eps
* CelticB.eps

# License

MSPL
