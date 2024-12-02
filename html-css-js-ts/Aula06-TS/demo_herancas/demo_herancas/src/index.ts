class Produto {
    #nome:string;
    #preco:number;

    constructor(nome:string, preco:number) {
        this.#nome = nome;
        this.#preco = preco;
    }

    get nome() {
        return this.#nome;
    }

    get preco() {
        return this.#preco;
    }

    set preco(valor:number) {
        this.#preco = valor;
    }

    toString() {
        return `[nome=${this.nome}, preco=${this.preco}]`;
    }
}

class ProdutoPerecivel extends Produto {
    #dataValidade:Date

    constructor(nome:string, preco:number, dataValidade:Date) {
        super(nome, preco);
        this.#dataValidade = dataValidade;
    }

    get dataValidade() {
        return this.#dataValidade;
    }

    toString() {
        return super.toString() + `[dataValidade=${this.dataValidade}]`;
    }
}

const p1 = new Produto('produto 1', 1.99);
const p2 = new ProdutoPerecivel('produto 2', 2.50, new Date(2025, 12, 24));
console.log(p2.nome);
p2.preco = 3.45;
console.log(p2.preco);
console.log(p2.dataValidade);
console.log(p2.toString());

abstract class FiguraBidimensional {
    #centrox: number;
    #centroy: number;

    constructor(x:number, y:number) {
        this.#centrox = x;
        this.#centroy = y;
    }

    get x() {
        return this.#centrox;
    }

    get y() {
        return this.#centroy;
    }

    abstract area(): number;
}

class Circulo extends FiguraBidimensional {
    #raio: number;

    constructor(x:number, y:number, r:number) {
        super(x,y);
        this.#raio = r;
    }

    get raio() {
        return this.#raio;
    }

    area() {
        return Math.PI * this.#raio ** 2;
    }
}

const circ = new Circulo(1,2,3);
console.log(circ.x);
console.log(circ.y);
console.log(circ.raio);
console.log(circ.area());

function imprime(figura: FiguraBidimensional) {
    console.log(`X=${figura.x}, Y=${figura.y}`);
}

imprime(circ);

type imprimivel2d = {
    x:number;
    y:number;
};

function imprime2d(figura: imprimivel2d) {
    console.log(`X=${figura.x}, Y=${figura.y}`);
}

const obj = {x:10, y:20};
//imprime(obj); //erro de tipo
imprime2d(circ);
imprime2d(obj);