<template>
    <div class="row">
        <div class="col-sm-6 col-md-5 col-lg-4 col-xl-3" v-for="book in books" v-bind:key="book.id">
            <BookCard :book="book"></BookCard>
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
                    id: 0,
                    title: 'Metro 2033 - HARDCODED',
                    stock: 2,
                    price: 10.5
                }]
            }
        },
        async created() {
            this.books = (await axiosInstance.get('/books')).data;
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
