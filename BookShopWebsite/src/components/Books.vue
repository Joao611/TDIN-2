<template>
    <div class="products">
        <BookCard v-for="book in books" v-bind:key="book.id"></BookCard>
    </div>
</template>

<script>
    import axiosInstance from '../utils/axiosInstance';

    export default {
        name: 'Books',
        data() {
            return {
                books: [{
                    id: 1,
                    title: 'Metro 2033',
                    stock: 2
                }]
            }
        },
        async created() {
            this.books = await axiosInstance.get('/books');
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
