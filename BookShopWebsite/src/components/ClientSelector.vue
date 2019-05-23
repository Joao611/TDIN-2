<template>
    <div class="col-auto">
        <select class="form-control" v-model="client">
            <option v-for="client in clients" :key="client.id"
                    :value="client">
                {{client.name}}
            </option>
        </select>
    </div>
</template>

<script>
    import axiosInstance from '../utils/axiosInstance';

    export default {
        name: 'ClientSelector',
        data() {
            return {
                clients: [{
                    id: 0,
                    name: 'J.R.R. Tolkien',
                }],
            }
        },
        async created() {
            this.clients = (await axiosInstance('/clients')).data;
        },
        methods: {
            setActiveClient(c) {
                this.$store.dispatch('setActiveClient', c);
            }
        },
        computed: {
            client: {
                get() {
                    return this.$store.state.client;
                },
                set(c) {
                    this.$store.commit('setActiveClient', c);
                }
            }
        },
    }
</script>

<style scoped>
</style>