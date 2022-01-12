<template>
    <div v-if="isReady">
        <h3>Timezone</h3>
        <div class="timezone-info">
            <p v-show="isFormVisible">
                <select :value="value" v-on:input="updateValue">
                    <option v-for="t in timezones" :value="t.id" :key="t.id">{{t.name}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!isFormVisible">
                {{timezoneName}}
                <a href="#" @click.prevent="open">Change</a>
            </p>
        </div>
    </div>
</template>

<script setup lang="ts">
    import { Timezone } from '@/types/Timezone';
    import { computed, ref } from 'vue';

    const props = defineProps<{
        value: string,
        timezones: Timezone[]
    }>();

    const emit = defineEmits(['input']);

    const isFormVisible = ref(false);

    const timezoneName = computed(() => {
        for (const c of props.timezones) {
                if (c.id === props.value) {
                    return c.name;
                }
            }
            return '';
    });

    const isReady = computed(() => {
        return !!props.timezones.length;
    });

    const open = (): void => {
        isFormVisible.value = true;
    };

    const close = (): void => {
        isFormVisible.value = false;
    };

    const updateValue = (event: Event) => {
        close();
        const value = (event.target as HTMLInputElement).value;
        emit('input', value);
    }
</script>
