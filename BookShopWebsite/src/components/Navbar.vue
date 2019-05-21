<template>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarContent">
            <ul class="navbar-nav mr-auto">
                <router-link tag="li" class="nav-item" v-for="route in links" v-bind:key="route.id"
                             :to="`${route.page}`">{{route.text}}</router-link>
            </ul>
        </div>
    </nav>
</template>

<script>
    export default {
        name: 'Navbar',
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
