console.log("--------MAPAS--------");
const mapa = new Map<string,string>();
mapa.set('RS', 'Rio Grande do Sul');
mapa.set('SC', 'Santa Catarina');
mapa.set('PR', 'Paraná');
console.log(mapa.get('RS'));

//varias colecoes suportam ITERADORES

for(let sigla of mapa.keys()) {
 console.log(sigla);
}
// keys - retorna algo iteravel sobre as chaves

for(let estado of mapa.values()) {
 console.log(estado);
}
for(let entrada of mapa.entries()) {
 console.log(entrada);
}

console.log("--------CONJUNTOS--------");
let conjunto = new Set<number>();
conjunto.add(1);
conjunto.add(1);
conjunto.add(2);
console.log(conjunto.size);
conjunto.forEach(x => console.log(x));
const array = [...conjunto];
console.log(array);

