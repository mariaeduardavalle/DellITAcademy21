let saudacao: string = 'Alô, mundo!';
console.log(saudacao);
function saudar(){
    console.log('Alo mundo');
}
saudar();

function saudarComNome(nome: string){
    console.log(`Alo, ${nome}`)
}
saudarComNome('Girls');

function criarSaudacao(nome: string){
    return `Alo, ${nome}`;
}
console.log(criarSaudacao('Girls 2'));

// function potencia(base: bigint, expoente: bigint){
//     let resultado = 1n;
//     for (let cont = 0n; cont < expoente; cont++){
//         resultado = resultado * base;
//     }
//     return resultado;
// }
//console.log(potencia(2n,10n));

function potencia(base: bigint, expoente = 0n){
    let resultado = 1n;
    for (let cont = 0n; cont < expoente; cont++){
        resultado = resultado * base;
    }
    return resultado;
}
console.log(potencia(2n,10n));
console.log(potencia(10n));

const saudarAnonima = function (nome: string) {
    return ('Girls 2');
}

console.log(saudarAnonima);
console.log(saudarAnonima('Girls 3'));

const saudarArrow = (nome : string) => `Alo, ${nome}`;
console.log(saudarArrow('Girls 4'));

// function multiplicar (fator: number){
//     return numero => numero * fator;
// } //alta ordem

// function multiplicar (fator: number){
//     return (numero: number) => numero * fator;
// }

function multiplicar (fator: number) : (n: number) => number {
    return numero => numero * fator;
}

const dobrar = multiplicar(2); 
const triplicar = multiplicar(3);

console.log(dobrar(2));
console.log(triplicar(5));

console.log(multiplicar(2)(5));