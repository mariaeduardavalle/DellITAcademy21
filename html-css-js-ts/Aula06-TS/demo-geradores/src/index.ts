const umArray = ['a','b','c'];
const iterator = umArray[Symbol.iterator]();
console.log(iterator.next());
console.log(iterator.next());
console.log(iterator.next());
console.log(iterator.next());

const umArray1 = ['a','b','c'];
const iterator1 = umArray1[Symbol.iterator]();
let resultado = iterator1.next();
while(!resultado.done) {
    console.log(resultado.value);
    resultado = iterator1.next();
}

const umArray2 = ['a','b','c'];
const iterator2 = umArray2[Symbol.iterator]();
let resultado1;
while(!(resultado1 = iterator2.next()).done) {
    console.log(resultado1.value);
}

const umConjunto = new Set<number>().add(1).add(2).add(3);
const umArray3 = [...umConjunto];
console.log(umArray3);

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

function* funcaoGeradora1() {
    let valor = 1;
    while(valor <= 3) {
        yield valor++;
    }
}
for(const i of funcaoGeradora1()) {
    console.log(i);
}
        

