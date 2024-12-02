const umArray = ['a','b','c'];
const iterator = umArray[Symbol.iterator]();
console.log(iterator.next());
console.log(iterator.next());
console.log(iterator.next());
console.log(iterator.next());

const iterador2 = umArray[Symbol.iterator]();
let resultado = iterador2.next();
while(!resultado.done) {
    console.log(resultado.value);
    resultado = iterador2.next();
}

function constroiArray<T>(colecao: Iterable<T>) {
    return [...colecao];
}

//construindo um array a partir de uma funcao com operador ....
const conjunto = new Set<number>().add(1).add(2).add(3);
const array = constroiArray(conjunto);
console.log(array);

function* funcaoGeradora() {
    yield 1;
    yield 2;
    yield 3;
}

const gerador = funcaoGeradora();
console.log(gerador.next());
console.log(gerador.next());
console.log(gerador.next());
console.log(gerador.next());


function* funcaoGeradora2() {
    let valor = 1;
    while (valor <= 3) {
        yield valor++;
    }
}

for(const valor of funcaoGeradora2()) {
    console.log(valor);
}