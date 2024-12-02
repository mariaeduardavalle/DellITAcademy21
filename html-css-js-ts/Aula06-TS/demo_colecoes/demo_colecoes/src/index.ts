const mapa = new Map<string,string>();

mapa.set('RS', 'Rio Grande do Sul');
mapa.set('SC', 'Santa Catarina');
mapa.set('PR', 'Parana');

console.log(mapa.get('RS'));

//varias colecoes suportam ITERADORES 
for (const e of mapa){
    console.log(e);
}

//iterar sobre as chaves
for (const chave of mapa.keys()){
//keys - retorna algo iteravel sobre as chaves
    console.log(chave);
}

for (const valores of mapa.values()){
    console.log(valores);
}


const conjunto = new Set<number>();
conjunto.add(1);
conjunto.add(2);
conjunto.add(1);
console.log(conjunto.size);
const array = [...conjunto];
console.log(array);

const conjuntomisto = new Set<number|string>();
conjuntomisto.add(1);
conjuntomisto.add('teste');
conjuntomisto.forEach(e => console.log(e));
