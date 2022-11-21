# Encoding-Program
encrypts and decrypts your passcodes so you can write them down safely.

How to use:

The code & included files are unfortunately a mess since I needed to make various versions of it for my submittion in ISH... I will try to clean it as best as I can.

However, the three important parts of the code are the files:

1. Form1.cs (code itself)9
2. Program.cs 
3. Form1.Designer (run this to see the application UI)

Okay so how do you use it? Well first you need to adminster an encryption/decryption key. 

On Form1.cs you will find on Line 108 (encryption) & Line 139 (decryption) a mathematical formula. The area you are looking for looks like this :

(c - x * 5) or (c + x / 5) etc....

The currently implemented formula is very basic, if you are actually going to use it to encrypt passcodes find a formula that is not basic artimithic, just remember you know how to solve it for the decryption process!

Remember that c must be included in the formula because this is the variable that contains your passcode and is what you are applying your formula to. 

By changing the formula you change the encryption process, this codes reformats the individual numbers per character (ASCII) according to your formula. 

ONLY CHANGE THE FORMULA INSIDE THE PARAENTHESIS OTHERWISE IT WILL NOT WORK.
