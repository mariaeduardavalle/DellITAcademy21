//Classe com propriedades públicas
class Pessoa {
    nome: string;
    idade: number;
    constructor(umNome:string, umaIdade:number) {
        this.nome = umNome;
        this.idade = umaIdade;
    }
}
const p1 = new Pessoa('John Doe', 22);
const p2 = new Pessoa('Mary Doe', 25);
console.log(typeof p1);
console.log(p1.nome);
console.log(p1.idade);

//Classe com propriedades privadas
class PessoaV2 {
    #nome: string;
    #idade: number;
    #peso = 0;

    constructor(umNome:string, umaIdade:number) {
        this.#nome = umNome;
        this.#idade = umaIdade;
    }

    get nome() {
        return this.#nome;
    }

    get idade() {
        return this.#idade;
    }

    get peso() {
        return this.#peso;
    }

    set peso(novoPeso:number) {
        this.#peso = novoPeso;
    }

    fazAniversario() {
        this.#idade = this.#idade + 1;
    }
}

const p3 = new PessoaV2('Nova pessoa', 20);
console.log(p3.idade);
console.log(p3.peso);
p3.peso = 50;
p3.fazAniversario();
console.log(p3.idade);
console.log(p3.peso);

//Classe com propriedades públicas via construtor
class PessoaV3 {
    constructor(public nome:string, public idade:number){}
}

const p4 = new PessoaV3('John Doe', 22);
console.log(p4.nome);