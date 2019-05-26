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
    export default {
        name: 'ClientSelector',
        computed: {
            clients: {
                get() {
                    return this.$store.state.clients;
                },
            },
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