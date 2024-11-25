console.log("--------------------------------------");
console.log("Laboratório 2 – Introdução ao TypeScript");
console.log("--------------------------------------");

console.log("#1.");
function imprimirParesFor(inicio: number, fim: number): void {
    for (let i = inicio; i <= fim; i++) {
        if (i % 2 === 0) {
            console.log(i);
        }
    }
}
console.log(imprimirParesFor(1,20));

function imprimirParesWhile(inicio: number, fim: number): void {
    let i = inicio;
    while (i <= fim) {
        if (i % 2 === 0) {
            console.log(i);
        }
        i++;
    }
}
console.log(imprimirParesWhile(5,35));

/*console.log("#2.");
let i: number = 0;
while (i != 10) {
    i += 0.2;
}
Resultado: O loop é infinito.
Explicação: A soma repetida de números de ponto flutuante (como 0.2) não resulta em valores exatos devido a imprecisões de representação binária dos números no JavaScript. Isso impede que i seja exatamente igual a 10.*/

console.log("#3.");
function min(x: number, y: number): number {
    return x < y ? x : y;
}
console.log(min(5,4));

console.log("#4.");
function powIterativo(x: number, y: number): number {
    let resultado = 1;
    for (let i = 0; i < y; i++) {
        resultado *= x;
    }
    return resultado;
}
console.log(powIterativo(4,3));

function powRecursivo(x: number, y: number): number {
    if (y === 0) return 1;
    return x * powRecursivo(x, y - 1);
}
console.log(powRecursivo(5,4));

console.log("#5.");
function toMaiusculaPrimeira(s: string): string {
    return s.charAt(0).toUpperCase() + s.slice(1);
}
console.log(toMaiusculaPrimeira('lápis'));


console.log("#6.");
function getMax(arr: number[]): number {
    let max = arr[0];
    for (let i = 1; i < arr.length; i++) {
        if (arr[i] > max) {
            max = arr[i];
        }
    }
    return max;
}
console.log(getMax([4,2,7,3,63,84,21,5]));

console.log("#7.");
function getMaxWithAPI(arr: number[]): number {
    return Math.max(...arr);
}
console.log(getMaxWithAPI([4,2,7,3,63,84,21,5]));

console.log("#8.");
function calcularFrequencia(arr: number[]): Map<number, number> {
    const frequencia = new Map<number, number>();

    for (const num of arr) {
        frequencia.set(num, (frequencia.get(num) || 0) + 1);
    }

    return frequencia;
}

console.log(calcularFrequencia([1,1,1,2,2,2,2,2,3,5,5,4,4,4,21]));

// Exemplo de uso
const arr = [1, 2, 2, 3, 3, 3, 4, 4, 4, 4];
const resultado = calcularFrequencia(arr);

// Exibindo a frequência
resultado.forEach((valor, chave) => {
    console.log(`Número ${chave}: ${valor} vezes`);
});
