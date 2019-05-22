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

    export default {
        name: 'app',
        components: {
            Books,
            Navbar
        },
        router
    };
</script>

<style>
</style>
