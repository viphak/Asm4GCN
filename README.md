# Asm4GCN - GCN Assembler for AMD GPUs
## an assembler/compiler for AMD’s GCN (Generation Core Next Architecture) Assembly Language

See the Article on CodeProject at http://www.codeproject.com/Articles/872477/Assembler-for-AMD-s-GCN-GPU for more details.

###Change History
- Feb 16 2015
  - Note: Initial Public Release
- Mar 1 2015
  - Added: ren command - A rename command has been added.  This allows a variable to be renamed as its use changes.
  - Improved: enlarged the auto-complete box - it now fits the code a little better.
  - Improved: Cleaned up example code.
  - Improved: Syntax Highlighting - it now highlights, labels, registers, and defines.  It also highlights matching words.
  - Improved: Updated CodeProject article
  - Fix: Variables would always use register 0
  - Fix: Removed single __asm4GCN block limitation - There can now be many __asm4GCN kernels in one program.
  - Change: Parameter names removed - Since the Parameter names are not used having them there could be confusing.  Function headers are now in the form: __asm4GCN myAsmAddFunc (float*,float*){...}
  - Change: merged #ref command into normal variable declarations. Since the #ref command is almost identical to normal variable declarations except that it specifies a register it is best to combine these.  It is cleaner and less confusing. Instead of the format for a ref being #ref s8u myVar s[2:3]  is now just s8u myVar s[2:3].
  - Removed: Auto compile skip function.  This function would skip a re-compile if there were no changes in the code windows. It was removed because it added complexity in the code and there was hardly any performance benefit since the compile process is so fast anyway. 
- April 22 2015
  - Posted on GitHub
- July 10 2015
  - Fix: Fixed bug in SAPP encoding.  Jumps were not working properly.
  - Fix: Auto-complete was not working on the GCN tab - it has been fixed.
- July 18 2015
  - Change: Switched the OpenCL wrapper to use NOpenCL by Tunnel Vision Laboratories. This is an awesome well-written wrapper.
  - Added: Indexing on variables.  (i.e.  myVar[1] would access the 2nd register in myVar)
  - Added: VINTRP encoded instructions
  - Updated: Updated article
 - August 2 2015
  - New: Variables automatically free themselves on the last line they were used.
  - New: Jumps can now be used in front of any statement and not just by line.
  - Refactor: Added variables class
  - Refactor: Moved variable functionality into Variable class
  - Refactor: reworked how jump functionality
  - Refactor: everything used to be done in one-pass and now it is in two-passes
     1) Pass 1 - read in all statements and record positions of vars
     2) Process automatic variable freeing
     3) Process register assignments for variables
     4) Pass 2 - convert statements to bin
  - Removed: Removed the 'ren' function as it resulted in ugly code. The same can be accomplished by declaring vars with specified registers.
  - Broken: variable indexing is broken ( I am fixing this next)
- August 9 2015
  - New: multiple labels intermixed with statements can now be added to a single line
  - New: Freed Variable registers can now be re-used in the same instruction.
  - New: Inline variable decorations (e.g. v_mov_b32 v4u myNewVar, anyVar )
  - New: lines ending with '/' will append the following line. #defines and statements can be split across lines.
  - New: Cleaned up initial code and added a #define(...) to easily view any S or V variable.
  - New: Added Ctrl-Y as an redo operator for Visual Studio users.
  - New: Additional variable warning checking (like when it is never used or used only once)
  - New: When declaring variables an existing variable, with an option index, as the register you want \
to re-use.
  - Change: Spaces can no longer be used to separate operands. Only commas can be used. This does not apply to trailing instruction option parameters.
  - Change: Defines are now processed before labels.
  - Change: Defines are now processed in reverse order so defines replacements can contain previous #define replacements. 
  - Fix: multi-register variables were not always aligned properly.
  - Fix: Fixed issue with variable indexes 
  - Fix: syntax color highlighting issue on GCN tab where not all text was always highlight properly.
