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
    import Vuex, { mapState } from 'vuex';

    Vue.use(Vuex);

    const store = new Vuex.Store({
        state: {
            client: {
                id: Number,
                name: String,
            }
        },
        mutations: {
            setActiveClient(state, newClient) {
                state.client = newClient;
            }
        },
        actions: {
            setActiveClient({ commit }, newClient) {
                commit('setActiveClient', newClient);
            }
        },
        computed: mapState([
            'client',
        ]),
    });

    export default {
        name: 'app',
        components: {
            Books,
            Navbar
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
