const pessoa = {
    nome: 'John Doe',
    idade: 22
};

console.log(pessoa.nome);
console.log(pessoa.idade);
pessoa.idade = 23;
console.log(pessoa.idade);
console.log(typeof pessoa);

//prototype permite criar novos objetos a partir desssa estrutura
//copiando e instanciando novos objetos

const outraPessoa = {
    nome: 'John Doe',
    idade: 22,
    saudar: function () {
        return `Meu nome é ${this.nome}`;
    }
};
console.log(outraPessoa.saudar());

const maisOutraPessoa = {
    nome: 'John Doe',
    idade: 22,
    saudar() {
        return `Meu nome é ${this.nome}`;
    }
};

console.log(maisOutraPessoa.saudar());

type Pessoa = {
    nome: string;
    idade: number;
    vivo?: boolean;
};

function saudar(umaPessoa: Pessoa) {
    console.log(`Alô, ${umaPessoa.nome}!`);
}

saudar(pessoa);
saudar(outraPessoa);
saudar(maisOutraPessoa);

const temperatura = {
    celsius: 23,
    get fahrenheit() {
        return this.celsius * 1.8 + 32;
    }
};

console.log(temperatura.celsius);
console.log(temperatura.fahrenheit);

const outraTemperatura = Object.create(temperatura);
//outraTemperatura.celsiuss = 13; //bug!
console.log(outraTemperatura.celsius);
console.log(outraTemperatura.fahrenheit);