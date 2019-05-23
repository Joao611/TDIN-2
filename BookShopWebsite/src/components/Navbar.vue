<template>
    <nav class="navbar navbar-expand-sm navbar-dark bg-dark">
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item" v-for="route in links" v-bind:key="route.id">
                    <router-link tag="a" class="nav-link" :to="`${route.page}`">{{route.text}}</router-link>
                </li>
            </ul>
            <router-link tag="button" to="/register" class="btn btn-warning">+</router-link>
            <ClientSelector></ClientSelector>
        </div>
    </nav>
</template>

<script>
    import ClientSelector from './ClientSelector';

    export default {
        name: 'Navbar',
        components: {
            ClientSelector,
        },
        data() {
            return {
                links: [
                    {
                        id: 0,
                        text: 'Products',
                        page: '/'
                    },
                    {
                        id: 1,
                        text: 'Orders',
                        page: '/orders'
                    }
                ]
            }
        }
    }
</script>

<style scoped>
</style>
