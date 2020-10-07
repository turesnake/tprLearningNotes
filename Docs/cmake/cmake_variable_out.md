### +++++ cmake variable info +++++ ###


num of cmake variables is: 51.



# =========================#
# +++ 1 +++
# ----------
CMAKE_AR
--------

Name of archiving tool for static libraries.

This specifies the name of the program that creates archive or static
libraries.


# =========================#
# +++ 2 +++
# ----------
CMAKE_BINARY_DIR
----------------

The path to the top level of the build tree.

This is the full path to the top level of the current CMake build
tree.  For an in-source build, this would be the same as
``CMAKE_SOURCE_DIR``.

When run in -P script mode, CMake sets the variables
``CMAKE_BINARY_DIR``, ``CMAKE_SOURCE_DIR``,
``CMAKE_CURRENT_BINARY_DIR`` and
``CMAKE_CURRENT_SOURCE_DIR`` to the current working directory.


# =========================#
# +++ 3 +++
# ----------
CMAKE_BUILD_TOOL
----------------

This variable exists only for backwards compatibility.
It contains the same value as ``CMAKE_MAKE_PROGRAM``.
Use that variable instead.


#=========================#
#+++ 4 +++
#----------
CMAKE_CACHEFILE_DIR
-------------------

The directory with the ``CMakeCache.txt`` file.

This is the full path to the directory that has the ``CMakeCache.txt``
file in it.  This is the same as ``CMAKE_BINARY_DIR``.


#=========================#
#+++ 5 +++
#----------
CMAKE_CACHE_MAJOR_VERSION
-------------------------

Major version of CMake used to create the ``CMakeCache.txt`` file

This stores the major version of CMake used to write a CMake cache
file.  It is only different when a different version of CMake is run
on a previously created cache file.


#=========================#
#+++ 6 +++
#----------
CMAKE_CACHE_MINOR_VERSION
-------------------------

Minor version of CMake used to create the ``CMakeCache.txt`` file

This stores the minor version of CMake used to write a CMake cache
file.  It is only different when a different version of CMake is run
on a previously created cache file.


#=========================#
#+++ 7 +++
#----------
CMAKE_CACHE_PATCH_VERSION
-------------------------

Patch version of CMake used to create the ``CMakeCache.txt`` file

This stores the patch version of CMake used to write a CMake cache
file.  It is only different when a different version of CMake is run
on a previously created cache file.


#=========================#
#+++ 8 +++
#----------
CMAKE_CFG_INTDIR
----------------

Build-time reference to per-configuration output subdirectory.

For native build systems supporting multiple configurations in the
build tree (such as :ref:`Visual Studio Generators` and ``Xcode``),
the value is a reference to a build-time variable specifying the name
of the per-configuration output subdirectory.  On :ref:`Makefile Generators`
this evaluates to `.` because there is only one configuration in a build tree.
Example values:

::

 $(ConfigurationName) = Visual Studio 8, 9
 $(Configuration)     = Visual Studio 10
 $(CONFIGURATION)     = Xcode
 .                    = Make-based tools

Since these values are evaluated by the native build system, this
variable is suitable only for use in command lines that will be
evaluated at build time.  Example of intended usage:

::

 add_executable(mytool mytool.c)
 add_custom_command(
   OUTPUT out.txt
   COMMAND ${CMAKE_CURRENT_BINARY_DIR}/${CMAKE_CFG_INTDIR}/mytool
           ${CMAKE_CURRENT_SOURCE_DIR}/in.txt out.txt
   DEPENDS mytool in.txt
   )
 add_custom_target(drive ALL DEPENDS out.txt)

Note that ``CMAKE_CFG_INTDIR`` is no longer necessary for this purpose but
has been left for compatibility with existing projects.  Instead
``add_custom_command()`` recognizes executable target names in its
``COMMAND`` option, so
``${CMAKE_CURRENT_BINARY_DIR}/${CMAKE_CFG_INTDIR}/mytool`` can be replaced
by just ``mytool``.

This variable is read-only.  Setting it is undefined behavior.  In
multi-configuration build systems the value of this variable is passed
as the value of preprocessor symbol ``CMAKE_INTDIR`` to the compilation
of all source files.


#=========================#
#+++ 9 +++
#----------
CMAKE_COMMAND
-------------

The full path to the ``cmake(1)`` executable.

This is the full path to the CMake executable ``cmake(1)`` which is
useful from custom commands that want to use the ``cmake -E`` option for
portable system commands.  (e.g.  ``/usr/local/bin/cmake``)


#=========================#
#+++ 10 +++
#----------
CMAKE_CROSSCOMPILING
--------------------

Is CMake currently cross compiling.

This variable will be set to true by CMake if CMake is cross
compiling.  Specifically if the build platform is different from the
target platform.


#=========================#
#+++ 11 +++
#----------
CMAKE_CTEST_COMMAND
-------------------

Full path to ``ctest(1)`` command installed with CMake.

This is the full path to the CTest executable ``ctest(1)`` which is
useful from custom commands that want to use the ``cmake(1)`` ``-E``
option for portable system commands.


#=========================#
#+++ 12 +++
#----------
CMAKE_CURRENT_BINARY_DIR
------------------------

The path to the binary directory currently being processed.

This the full path to the build directory that is currently being
processed by cmake.  Each directory added by ``add_subdirectory()`` will
create a binary directory in the build tree, and as it is being
processed this variable will be set.  For in-source builds this is the
current source directory being processed.

When run in -P script mode, CMake sets the variables
``CMAKE_BINARY_DIR``, ``CMAKE_SOURCE_DIR``,
``CMAKE_CURRENT_BINARY_DIR`` and
``CMAKE_CURRENT_SOURCE_DIR`` to the current working directory.


#=========================#
#+++ 13 +++
#----------
CMAKE_CURRENT_LIST_DIR
----------------------

Full directory of the listfile currently being processed.

As CMake processes the listfiles in your project this variable will
always be set to the directory where the listfile which is currently
being processed (``CMAKE_CURRENT_LIST_FILE``) is located.  The value
has dynamic scope.  When CMake starts processing commands in a source file
it sets this variable to the directory where this file is located.
When CMake finishes processing commands from the file it restores the
previous value.  Therefore the value of the variable inside a macro or
function is the directory of the file invoking the bottom-most entry
on the call stack, not the directory of the file containing the macro
or function definition.

See also ``CMAKE_CURRENT_LIST_FILE``.


#=========================#
#+++ 14 +++
#----------
CMAKE_CURRENT_LIST_FILE
-----------------------

Full path to the listfile currently being processed.

As CMake processes the listfiles in your project this variable will
always be set to the one currently being processed.  The value has
dynamic scope.  When CMake starts processing commands in a source file
it sets this variable to the location of the file.  When CMake
finishes processing commands from the file it restores the previous
value.  Therefore the value of the variable inside a macro or function
is the file invoking the bottom-most entry on the call stack, not the
file containing the macro or function definition.

See also ``CMAKE_PARENT_LIST_FILE``.


#=========================#
#+++ 15 +++
#----------
CMAKE_CURRENT_LIST_LINE
-----------------------

The line number of the current file being processed.

This is the line number of the file currently being processed by
cmake.


#=========================#
#+++ 16 +++
#----------
CMAKE_CURRENT_SOURCE_DIR
------------------------

The path to the source directory currently being processed.

This the full path to the source directory that is currently being
processed by cmake.

When run in -P script mode, CMake sets the variables
``CMAKE_BINARY_DIR``, ``CMAKE_SOURCE_DIR``,
``CMAKE_CURRENT_BINARY_DIR`` and
``CMAKE_CURRENT_SOURCE_DIR`` to the current working directory.


#=========================#
#+++ 17 +++
#----------
CMAKE_DL_LIBS
-------------

Name of library containing ``dlopen`` and ``dlclose``.

The name of the library that has ``dlopen`` and ``dlclose`` in it, usually
``-ldl`` on most UNIX machines.


#=========================#
#+++ 18 +++
#----------
CMAKE_EDIT_COMMAND
------------------

Full path to ``cmake-gui(1)`` or ``ccmake(1)``.  Defined only for
:ref:`Makefile Generators` when not using an "extra" generator for an IDE.

This is the full path to the CMake executable that can graphically
edit the cache.  For example, ``cmake-gui(1)`` or ``ccmake(1)``.


#=========================#
#+++ 19 +++
#----------
CMAKE_EXECUTABLE_SUFFIX
-----------------------

The suffix for executables on this platform.

The suffix to use for the end of an executable filename if any, ``.exe``
on Windows.

``CMAKE_EXECUTABLE_SUFFIX_<LANG>`` overrides this for language ``<LANG>``.


#=========================#
#+++ 20 +++
#----------
CMAKE_EXTRA_GENERATOR
---------------------

The extra generator used to build the project.  See
``cmake-generators(7)``.

When using the Eclipse, CodeBlocks or KDevelop generators, CMake
generates Makefiles (``CMAKE_GENERATOR``) and additionally project
files for the respective IDE.  This IDE project file generator is stored in
``CMAKE_EXTRA_GENERATOR`` (e.g.  ``Eclipse CDT4``).


#=========================#
#+++ 21 +++
#----------
CMAKE_EXTRA_SHARED_LIBRARY_SUFFIXES
-----------------------------------

Additional suffixes for shared libraries.

Extensions for shared libraries other than that specified by
``CMAKE_SHARED_LIBRARY_SUFFIX``, if any.  CMake uses this to recognize
external shared library files during analysis of libraries linked by a
target.


#=========================#
#+++ 22 +++
#----------
CMAKE_GENERATOR
---------------

The generator used to build the project.  See ``cmake-generators(7)``.

The name of the generator that is being used to generate the build
files.  (e.g.  ``Unix Makefiles``, ``Ninja``, etc.)


#=========================#
#+++ 23 +++
#----------
CMAKE_HOME_DIRECTORY
--------------------

Path to top of source tree.

This is the path to the top level of the source tree.


#=========================#
#+++ 24 +++
#----------
CMAKE_IMPORT_LIBRARY_PREFIX
---------------------------

The prefix for import libraries that you link to.

The prefix to use for the name of an import library if used on this
platform.

``CMAKE_IMPORT_LIBRARY_PREFIX_<LANG>`` overrides this for language ``<LANG>``.


#=========================#
#+++ 25 +++
#----------
CMAKE_IMPORT_LIBRARY_SUFFIX
---------------------------

The suffix for import libraries that you link to.

The suffix to use for the end of an import library filename if used on
this platform.

``CMAKE_IMPORT_LIBRARY_SUFFIX_<LANG>`` overrides this for language ``<LANG>``.


#=========================#
#+++ 26 +++
#----------
CMAKE_LINK_LIBRARY_SUFFIX
-------------------------

The suffix for libraries that you link to.

The suffix to use for the end of a library filename, ``.lib`` on Windows.


#=========================#
#+++ 27 +++
#----------
CMAKE_MAJOR_VERSION
-------------------

First version number component of the ``CMAKE_VERSION``
variable.


#=========================#
#+++ 28 +++
#----------
CMAKE_MAKE_PROGRAM
------------------

Tool that can launch the native build system.
The value may be the full path to an executable or just the tool
name if it is expected to be in the ``PATH``.

The tool selected depends on the ``CMAKE_GENERATOR`` used
to configure the project:

* The :ref:`Makefile Generators` set this to ``make``, ``gmake``, or
  a generator-specific tool (e.g. ``nmake`` for ``NMake Makefiles``).

  These generators store ``CMAKE_MAKE_PROGRAM`` in the CMake cache
  so that it may be edited by the user.

* The ``Ninja`` generator sets this to ``ninja``.

  This generator stores ``CMAKE_MAKE_PROGRAM`` in the CMake cache
  so that it may be edited by the user.

* The ``Xcode`` generator sets this to ``xcodebuild`` (or possibly an
  otherwise undocumented ``cmakexbuild`` wrapper implementing some
  workarounds).

  This generator prefers to lookup the build tool at build time
  rather than to store ``CMAKE_MAKE_PROGRAM`` in the CMake cache
  ahead of time.  This is because ``xcodebuild`` is easy to find,
  the ``cmakexbuild`` wrapper is needed only for older Xcode versions,
  and the path to ``cmakexbuild`` may be outdated if CMake itself moves.

  For compatibility with versions of CMake prior to 3.2, if
  a user or project explicitly adds ``CMAKE_MAKE_PROGRAM`` to
  the CMake cache then CMake will use the specified value.

* The :ref:`Visual Studio Generators` set this to the full path to
  ``MSBuild.exe`` (VS >= 10), ``devenv.com`` (VS 7,8,9), or
  ``VCExpress.exe`` (VS Express 8,9).
  (See also variables
  ``CMAKE_VS_MSBUILD_COMMAND`` and
  ``CMAKE_VS_DEVENV_COMMAND``.

  These generators prefer to lookup the build tool at build time
  rather than to store ``CMAKE_MAKE_PROGRAM`` in the CMake cache
  ahead of time.  This is because the tools are version-specific
  and can be located using the Windows Registry.  It is also
  necessary because the proper build tool may depend on the
  project content (e.g. the Intel Fortran plugin to VS 10 and 11
  requires ``devenv.com`` to build its ``.vfproj`` project files
  even though ``MSBuild.exe`` is normally preferred to support
  the ``CMAKE_GENERATOR_TOOLSET``).

  For compatibility with versions of CMake prior to 3.0, if
  a user or project explicitly adds ``CMAKE_MAKE_PROGRAM`` to
  the CMake cache then CMake will use the specified value if
  possible.

* The ``Green Hills MULTI`` generator sets this to ``gbuild``.
  If a user or project explicitly adds ``CMAKE_MAKE_PROGRAM`` to
  the CMake cache then CMake will use the specified value.

The ``CMAKE_MAKE_PROGRAM`` variable is set for use by project code.
The value is also used by the ``cmake(1)`` ``--build`` and
``ctest(1)`` ``--build-and-test`` tools to launch the native
build process.


#=========================#
#+++ 29 +++
#----------
CMAKE_MINOR_VERSION
-------------------

Second version number component of the ``CMAKE_VERSION``
variable.


#=========================#
#+++ 30 +++
#----------
CMAKE_PARENT_LIST_FILE
----------------------

Full path to the CMake file that included the current one.

While processing a CMake file loaded by ``include()`` or
``find_package()`` this variable contains the full path to the file
including it.  The top of the include stack is always the ``CMakeLists.txt``
for the current directory.  See also ``CMAKE_CURRENT_LIST_FILE``.


#=========================#
#+++ 31 +++
#----------
CMAKE_PATCH_VERSION
-------------------

Third version number component of the ``CMAKE_VERSION``
variable.


#=========================#
#+++ 32 +++
#----------
CMAKE_PROJECT_NAME
------------------

The name of the current project.

This specifies name of the current project from the closest inherited
``project()`` command.


#=========================#
#+++ 33 +++
#----------
CMAKE_RANLIB
------------

Name of randomizing tool for static libraries.

This specifies name of the program that randomizes libraries on UNIX,
not used on Windows, but may be present.


#=========================#
#+++ 34 +++
#----------
CMAKE_ROOT
----------

Install directory for running cmake.

This is the install root for the running CMake and the ``Modules``
directory can be found here.  This is commonly used in this format:
``${CMAKE_ROOT}/Modules``


#=========================#
#+++ 35 +++
#----------
CMAKE_SHARED_LIBRARY_PREFIX
---------------------------

The prefix for shared libraries that you link to.

The prefix to use for the name of a shared library, ``lib`` on UNIX.

``CMAKE_SHARED_LIBRARY_PREFIX_<LANG>`` overrides this for language ``<LANG>``.


#=========================#
#+++ 36 +++
#----------
CMAKE_SHARED_LIBRARY_SUFFIX
---------------------------

The suffix for shared libraries that you link to.

The suffix to use for the end of a shared library filename, ``.dll`` on
Windows.

``CMAKE_SHARED_LIBRARY_SUFFIX_<LANG>`` overrides this for language ``<LANG>``.


#=========================#
#+++ 37 +++
#----------
CMAKE_SHARED_MODULE_PREFIX
--------------------------

The prefix for loadable modules that you link to.

The prefix to use for the name of a loadable module on this platform.

``CMAKE_SHARED_MODULE_PREFIX_<LANG>`` overrides this for language ``<LANG>``.


#=========================#
#+++ 38 +++
#----------
CMAKE_SHARED_MODULE_SUFFIX
--------------------------

The suffix for shared libraries that you link to.

The suffix to use for the end of a loadable module filename on this
platform

``CMAKE_SHARED_MODULE_SUFFIX_<LANG>`` overrides this for language ``<LANG>``.


#=========================#
#+++ 39 +++
#----------
CMAKE_SIZEOF_VOID_P
-------------------

Size of a ``void`` pointer.

This is set to the size of a pointer on the target machine, and is determined
by a try compile.  If a 64-bit size is found, then the library search
path is modified to look for 64-bit libraries first.


#=========================#
#+++ 40 +++
#----------
CMAKE_SKIP_RPATH
----------------

If true, do not add run time path information.

If this is set to ``TRUE``, then the rpath information is not added to
compiled executables.  The default is to add rpath information if the
platform supports it.  This allows for easy running from the build
tree.  To omit RPATH in the install step, but not the build step, use
``CMAKE_SKIP_INSTALL_RPATH`` instead.


#=========================#
#+++ 41 +++
#----------
CMAKE_SOURCE_DIR
----------------

The path to the top level of the source tree.

This is the full path to the top level of the current CMake source
tree.  For an in-source build, this would be the same as
``CMAKE_BINARY_DIR``.

When run in -P script mode, CMake sets the variables
``CMAKE_BINARY_DIR``, ``CMAKE_SOURCE_DIR``,
``CMAKE_CURRENT_BINARY_DIR`` and
``CMAKE_CURRENT_SOURCE_DIR`` to the current working directory.


#=========================#
#+++ 42 +++
#----------
Argument "CMAKE_STANDARD_LIBRARIES" to --help-variable is not a defined variable.  Use --help-variable-list to see all defined variables.


#=========================#
#+++ 43 +++
#----------
CMAKE_STATIC_LIBRARY_PREFIX
---------------------------

The prefix for static libraries that you link to.

The prefix to use for the name of a static library, ``lib`` on UNIX.

``CMAKE_STATIC_LIBRARY_PREFIX_<LANG>`` overrides this for language ``<LANG>``.


#=========================#
#+++ 44 +++
#----------
CMAKE_STATIC_LIBRARY_SUFFIX
---------------------------

The suffix for static libraries that you link to.

The suffix to use for the end of a static library filename, ``.lib`` on
Windows.

``CMAKE_STATIC_LIBRARY_SUFFIX_<LANG>`` overrides this for language ``<LANG>``.


#=========================#
#+++ 45 +++
#----------
CMAKE_TWEAK_VERSION
-------------------

Defined to ``0`` for compatibility with code written for older
CMake versions that may have defined higher values.

.. note::

  In CMake versions 2.8.2 through 2.8.12, this variable holds
  the fourth version number component of the
  ``CMAKE_VERSION`` variable.


#=========================#
#+++ 46 +++
#----------
Argument "CMAKE_USING_VC_FREE_TOOLS" to --help-variable is not a defined variable.  Use --help-variable-list to see all defined variables.


#=========================#
#+++ 47 +++
#----------
CMAKE_VERBOSE_MAKEFILE
----------------------

Enable verbose output from Makefile builds.

This variable is a cache entry initialized (to ``FALSE``) by
the ``project()`` command.  Users may enable the option
in their local build tree to get more verbose output from
Makefile builds and show each command line as it is launched.


#=========================#
#+++ 48 +++
#----------
CMAKE_VERSION
-------------

The CMake version string as three non-negative integer components
separated by ``.`` and possibly followed by ``-`` and other information.
The first two components represent the feature level and the third
component represents either a bug-fix level or development date.

Release versions and release candidate versions of CMake use the format::

 <major>.<minor>.<patch>[-rc<n>]

where the ``<patch>`` component is less than ``20000000``.  Development
versions of CMake use the format::

 <major>.<minor>.<date>[-<id>]

where the ``<date>`` component is of format ``CCYYMMDD`` and ``<id>``
may contain arbitrary text.  This represents development as of a
particular date following the ``<major>.<minor>`` feature release.

Individual component values are also available in variables:

* ``CMAKE_MAJOR_VERSION``
* ``CMAKE_MINOR_VERSION``
* ``CMAKE_PATCH_VERSION``
* ``CMAKE_TWEAK_VERSION``

Use the ``if()`` command ``VERSION_LESS``, ``VERSION_GREATER``,
``VERSION_EQUAL``, ``VERSION_LESS_EQUAL``, or ``VERSION_GREATER_EQUAL``
operators to compare version string values against ``CMAKE_VERSION`` using a
component-wise test.  Version component values may be 10 or larger so do not
attempt to compare version strings as floating-point numbers.

.. note::

  CMake versions 2.8.2 through 2.8.12 used three components for the
  feature level.  Release versions represented the bug-fix level in a
  fourth component, i.e. ``<major>.<minor>.<patch>[.<tweak>][-rc<n>]``.
  Development versions represented the development date in the fourth
  component, i.e. ``<major>.<minor>.<patch>.<date>[-<id>]``.

  CMake versions prior to 2.8.2 used three components for the
  feature level and had no bug-fix component.  Release versions
  used an even-valued second component, i.e.
  ``<major>.<even-minor>.<patch>[-rc<n>]``.  Development versions
  used an odd-valued second component with the development date as
  the third component, i.e. ``<major>.<odd-minor>.<date>``.

  The ``CMAKE_VERSION`` variable is defined by CMake 2.6.3 and higher.
  Earlier versions defined only the individual component variables.


#=========================#
#+++ 49 +++
#----------
PROJECT_BINARY_DIR
------------------

Full path to build directory for project.

This is the binary directory of the most recent ``project()`` command.


#=========================#
#+++ 50 +++
#----------
PROJECT_NAME
------------

Name of the project given to the project command.

This is the name given to the most recent ``project()`` command.


#=========================#
#+++ 51 +++
#----------
PROJECT_SOURCE_DIR
------------------

Top level source directory for the current project.

This is the source directory of the most recent ``project()`` command.

||| ---- END ---- |||

