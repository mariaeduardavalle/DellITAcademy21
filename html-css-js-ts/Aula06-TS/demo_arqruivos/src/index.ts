import * as fs from 'node:fs';
//import { readFileSync, writeFileSync } from 'node:fs';
import { readFile } from 'node:fs/promises';


//Gravando arquivo de forma síncrona
const obj = {
    nome: 'John Doe',
    idade: 22
};
const json = JSON.stringify(obj);
try {
    fs.writeFileSync('dados.json', json);
} catch (error) {
    console.error('Falha de escrita no arquivo');
    console.error((error as Error).name);
    console.error((error as Error).message);
}


//Lendo arquivo de forma síncrona
try {
    const json = fs.readFileSync('dados.json','utf8');
    const obj = JSON.parse(json);
    console.log(obj);
} catch (error) {
    console.error('Falha de leitura/processamento do arquivo');
    console.error((error as Error).name);
    console.error((error as Error).message);
}



//Lendo arquivo de forma assíncrona com callback
console.log('início');
fs.readFile('dados.json', 'utf-8', (error, json) => {
    if (error) {
        console.error('Falha de leitura do arquivo');
        console.error(error.name);
        console.error(error.message);
    } else {
        try {
            const obj = JSON.parse(json);
            console.log(obj);
        } catch (error) {
            console.error('Falha de processamento do arquivo');
            console.error((error as Error).name);
            console.error((error as Error).message);
        }
    }
});
console.log('fim');



//Lendo arquivo de forma assíncrona com promise
console.log('início');
readFile('dados.json','utf8')
    .then(json => {
        const obj = JSON.parse(json);
        console.log(obj);
    })
    .catch(error => {
        console.error('Falha de leitura/processamento do arquivo');
        console.error((error as Error).name);
        console.error((error as Error).message);
    });
console.log('fim');


//Lendo arquivo de forma assíncrona com await
/*console.log('início');
try {
    const json = await readFile('dados.json', 'utf8');
    const obj = JSON.parse(json);
    console.log(obj);
} catch (error) {
    console.error('Falha de leitura/processamento do arquivo');
    console.error((error as Error).name);
    console.error((error as Error).message);
}
console.log('fim');*/