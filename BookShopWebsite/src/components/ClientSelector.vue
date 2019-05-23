<template>
    <div class="col-auto">
        <select class="form-control">
            <option v-for="client in clients" :key="client.id"
                    :value="client.id">
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
        }
    }
</script>

<style scoped>
</style>