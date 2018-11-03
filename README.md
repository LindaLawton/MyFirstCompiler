# MyFirstCompiler

This is my first attempt at making a compiler.  I am following along on with [Immo Landwerth](https://github.com/terrajobst) [Building a compiler](https://www.youtube.com/watch?v=wgHIkdUQbp0&list=PLRAdsfhKI4OWNOSfS7EUu5GRAVmze1t2y) series.

His repo is here [Minsk](https://github.com/terrajobst/minsk)

## Mission

Learn how to compilers work and create my own.  In order to do this I need to understand the code, what we are doing and why.  I cant just copy [Immo Landwerth](https://github.com/terrajobst) code. This means that I am going to have to remove the first version of the parser I added yesterday I couldnt understand it so just ended up copying his code.  So I think I am going to take a step back to day and rewach the youtube video starting at [Episode 1: A basic expression evaluator 31:26](https://youtu.be/wgHIkdUQbp0?t=1869) until I understand what the code is doing.  Now I am going to allow myself to do things diffrently thatn Immo I think thats fair all developers are diffrent and I may have a diffrent coding style than he does.   The fun thing in the end will be finding out if my changes get me into trouble or not.


## Noteable links

[Building a Compiler series](https://www.youtube.com/watch?v=wgHIkdUQbp0&feature=youtu.be&list=PLRAdsfhKI4OWNOSfS7EUu5GRAVmze1t2y)

[Episode 1: A basic expression evaluator](https://www.youtube.com/watch?v=wgHIkdUQbp0)
- Lexor  [Episode 1: A basic expression evaluator 16:11](https://youtu.be/wgHIkdUQbp0?t=971)
- Parser [Episode 1: A basic expression evaluator 31:26](https://youtu.be/wgHIkdUQbp0?t=1869)

## Notes

[Episode 1: A basic expression evaluator](https://www.youtube.com/watch?v=wgHIkdUQbp0)

I have a few issues with the first version of the Lexor.  I am not sure that its the Lexors job to parse ints into value objects.  What if its a negitive number.   1 + -1.  The inital lexor is going to parse that into six. With two number values of 1 where the second should have been -1 and a + and a - operator.  I think either the parser should be doing that or there should be a middle layer to turn things into their logical objects.   We will see what happends I havent watched the full video yet, I am taking it in chunks as its realy long.

