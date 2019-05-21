<template>
    <div class="row">
        <div class="col-lg-3" v-for="book in books">
            <BookCard v-bind:key="book.id" :book="book"></BookCard>
        </div>
    </div>
</template>

<script>
    import axiosInstance from '../utils/axiosInstance';
    import BookCard from './BookCard';

    export default {
        name: 'Books',
        components: {
            BookCard
        },
        data() {
            return {
                books: [{
                    id: 1,
                    title: 'Metro 2033 - HARDCODED',
                    stock: 2,
                    price: 10.5
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
