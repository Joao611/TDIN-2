<template>
    <div id="app">
        <Navbar></Navbar>
        <div class="container-fluid">
            <router-view />
        </div>
    </div>
</template>

<script>
    import Books from './components/Books.vue';
    import Navbar from './components/Navbar.vue';
    import router from './router/index';
    import Vue from 'vue';
    import Vuex from 'vuex';

    Vue.use(Vuex);

    const store = new Vuex.Store({
        state: {
            client: {
                id: Number,
                name: String,
            },
            images: [
                "https://static.fnac-static.com/multimedia/Images/PT/NR/35/14/40/4199477/1540-1.jpg",
                "https://static.fnac-static.com/multimedia/Images/PT/NR/4d/06/00/1613/1540-1.jpg",
                "https://images-na.ssl-images-amazon.com/images/I/41CMS%2BUF3EL._SX348_BO1,204,203,200_.jpg",
                "https://covers.oreillystatic.com/images/0636920032373/lrg.jpg",
                "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1533751609i/41073001._UY500_SS500_.jpg",
                "https://images.manning.com/720/960/resize/book/e/7ec6939-bdc8-464c-9037-88c66911896e/rademakers2.png",
                "http://images.impresa.pt/visao/2017-01-06-Diario-de-um-banana-2.jpg/original/mw-320",
                "https://static.fnac-static.com/multimedia/Images/PT/NR/cd/49/05/346573/1540-1.jpg",
                "https://images.livrariasaraiva.com.br/imagemnet/imagem.aspx/?pro_id=3663453&qld=90&l=430&a=-1=1000391981",
                "https://cache.skoob.com.br/local/images//w_inIfko4wqsQJqxj5maJZyyQpg=/200x/center/top/smart/filters:format(jpeg)/https://skoob.s3.amazonaws.com/livros/102089/A_LTIMA_GOTA_1429325363102089SK1429325363B.jpg",
                "https://static.fnac-static.com/multimedia/Images/PT/NR/d2/1d/0c/794066/1540-1/tsp20160819012304/O-Diario-de-um-Banana-Vol-8-Ora-Bolas-Caixa-Arquivadora.jpg",
                "https://www.booksmile.pt/media/cover/hd/9789897072833.jpg",
                "https://img.wook.pt/images/o-diario-de-um-banana-1-edicao-especial-toque-do-queijo-jeff-kinney/MXwyMjg1NTg2MnwxODczNTM2OHwxNTUwMTAyNDAwMDAw/250x",
                "https://www.booksmile.pt/media/cover/hd/9789898849007.jpg",
                "https://www.casasbahia-imagens.com.br/Control/ArquivoExibir.aspx?IdArquivo=243586814"
            ]
        },
        mutations: {
            setActiveClient(state, newClient) {
                state.client = newClient;
            }
        },
    });

    export default {
        name: 'app',
        components: {
            Books,
            Navbar,
        },
        router,
        store,
    };
</script>

<style>
    .pointer {
        cursor: pointer;
    }
</style>
