mov @string, r1
mov 0, r0
loop:
movb (r1)+,r2 ; перенос байта в r2 с увеличением индекса строки
cmpb 2E, r2 ; сравнение Rx-Ry
JZ end ; если точка то конец

mov 28, r3
cmpb r2,r3 ; сравнение Rx-Ry
JZ open ; если откр. скобка то переходим

mov 29, r3
cmpb r2,r3
JZ close ; если закр. скобка то переходим
jmp loop ; если левый символ начинаем цикл заново

open:
add 1, r0
jmp loop

close:
cmp 0,r0
JZ no_balance ; если закр. скобка пишется без откр. то не баланс, переходим
sub 1, r0
jmp loop

end:
cmp 0, r0
JZ balance
no_balance:
mov 0,r0
stop

balance:
mov 1,r0
stop

string:
data "((123))."
