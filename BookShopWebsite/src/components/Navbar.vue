<template>
    <nav>
        <router-link v-for="route in links" v-bind:key="route.id"
                     :to="`${route.page}`">{{route.text}}</router-link>
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
