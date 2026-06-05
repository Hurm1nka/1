mov @text, r1  ;кладем текст в r1
mov 0, r0 ; кладем 0 в r0, изначально не является

LOOP:
MOVB (r1)+, r2 ; перемещаем младший байт
               ; сдвигая указатель в строке +1

CMPB 68, R2 ; если в R2 лежит h, то это конец       ; 68-68 = 0
JZ END      ; если 0 прыгаем к флагу END

mov 30, r3
cmpb r2,r3 ; Rx-Ry
JL THIS_LETTER ; если символ < 30 => буква
mov 39, r3
cmpb r2,r3 ; Rx-Ry
JG THIS_LETTER ; если символ > 39 => буква
jmp THIS_DIGIT ; это цифра, прыгаем
                                             
THIS_LETTER:
mov 41, r3
cmpb r2, r3 ; Rx-Ry
JL NO_HEX   ; если символ < 41 то это не HEX,
mov 46, r3
cmpb r2, r3 ; Rx-Ry
JG NO_HEX ; если символ > 46 то это не HEX,

THIS_DIGIT:
mov 1, r0   ; в hex есть цифры поэтому является
jmp LOOP ; прыгаем обратно

NO_HEX:
MOV 0,r0
JMP FINISH

END:
cmp 0, r0
JZ NO_HEX
jmp FINISH

FINISH:
STOP

text:
data "A2h"

