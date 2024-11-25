const a = [1,2,3];

console.log(a);
console.log(a.length);

const b = Array<number>(3);
console.log(b);
console.log(b.length);

const c = [1, ,3];
console.log(c);
console.log(c.length);
console.log(c[1]);

const bcopia = Array<number>(3);
console.log(bcopia);
console.log(bcopia.length);
console.log(bcopia[0]);

const aa = [1,2,3];
console.log(aa);
aa.length = 6;
console.log(aa.length);
console.log(aa);

const ab = [1,2,3];
console.log(ab);
for(const v of ab){
    console.log(v);
}

let n = 4;
console.log(n);


console.log("For each: ");
const a1 = [1,2,3];
a1.forEach((v) => console.log(v));

console.log("---------------SORT-----------------");
const sa = [3,1,2];
sa.sort((x,y) => {
    if(x>y) return 1;
    if(x<y) return -1;
    return 0;
});
console.log(sa);

/*console.log("Criando buracos ...");
const bc = [3,,1,2];
bc.sort((x,y) => {
    if(x>y) return 1;
    if(x<y) return -1;
    return 0;
});
console.log(bc);*/

console.log("----------FILTER, MAP E REDUCE---------");
let numeros = [1,2,3,4,5,6,7,8,9,10];
let somatorio = numeros.filter(n => n % 2 === 0)
.map(a => a * 10)
.reduce((a,b) => a + b);
console.log(somatorio);

/*const numero : number[]=[];
const r = numero.reduce((a+b) => a+b);
console.log(r);*/


console.log("Desestruturação de um array: ");
//do lado esquerdo: atribuicai
//usa notação de um array para pegar os valores
const m = [1,2];
let [m1,m2] = m;
//m é um array - number - 
//m1 e m2 são number
console.log(m1, " , ",m2);


const j = [1,2,4,5];
let [j1,j2] = j;
console.log(j1, " , ", j2);

let arr = ['Julio', 'Machado'];
let [ , ultimoNome] = arr;
console.log(ultimoNome);

const rest = [1,2,4,5];
let [b1, ...b2] = rest;
console.log(b1);
console.log(b2);

let l: number[][] = [
    [1,2,3],
    [4,5,6],
    [7,8,9]
   ];
   console.log(l.length);
   console.log(l[0].length);
   console.log(l[1][2]);
   console.log(l);



