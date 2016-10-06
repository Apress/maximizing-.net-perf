Finding the code for a particular test:
All test cases have a C# comment in the form of "//TEST xx.xx", which corresponds to the number of the test in the book and on the UI.
The test can be found by doing a "Find in Files" (Ctrl-Shift-F) and searching for the test number, or by opening all the files for a particular
chapter, and adding "TEST" as a Comment Token so that it will shown up in the Task List.  To do this, select Tools | Options, and go to
the Environment\Task List form, and add Test.  C# Comment Tokens will only be displayed in the Task List (Ctrl-Alt-K) if the file is open,
so if you are after a Chapter 4 test, expend the "Strings" folder, select all the files, and hit Enter. 


Depedancies:
1. MSChart OCX needs to be installed and registered.  Included in the Redist folder.  The reg.bat can register MSChart if line 2 is uncommented.
2. InteropComTest.dll and InteropSafeArray.dll are required, and registered by reg.bat.
3. InteropDllTest.dll is a C-style DLL used in the interop tests.  It is included in Release directory by default.
4. VBExceptionHandling.dll is a VB.NET assembly built with the VBExceptionHandling project in the BookSample folder.  It is included in Release directory by default.
5. ExceptionHandling.dll is an IL assembly included in Release directory by default.  The source and build file is included in PerfTest\Exceptions\il.
6. The remoting tests require the remoting server to be running.  For the IIS test, IIS hosting must be configured for the web.config in the release directory.  It is recommended server is run on a seperate machine to the client-side tests.
7. The config file contains various remoting settings.
