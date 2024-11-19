'use scritct';

const botao = document.querySelector('.btn');

botao.addEventListener('click', ()=> {
    document.body.classList.toggle('light-theme');
    document.body.classList.toggle('dark-theme');
});

//toggle remove se esta presente e adiciona se não esta - faz a troca.

//agora vai mudar
const nameClassAtualBotao = document.body.className;
if(nameClassAtualBotao ==='light-theme'){
    this.textContext = 'Dark';
}else {
    this.textContext = 'Light';
}