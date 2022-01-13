<template>
    <div>
        <h3>Frequency</h3>
        <div class="frequency-info">
            <p v-show="isFormVisible">
                <select :value="modelValue" v-on:input="updateValue">
                    <option v-for="f in frequencies" :value="f.id" :key="f.id">{{f.name}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!isFormVisible">
                {{frequencyName}}
                <a href="#" @click.prevent="open">Change</a>
            </p>
        </div>
    </div>
</template>

<script setup lang="ts">
    import frequencies from '../frequencies';
    import { Frequency } from '@/types/Frequency';
    import { computed, ref } from 'vue';

    const props = defineProps<{
        modelValue: string,
        frequencies: Frequency[]
    }>();

    const emit = defineEmits(['update:modelValue']);

    const isFormVisible = ref(false);

    const frequencyName = computed(() => {
        for (const c of props.frequencies) {
            if (c.id === props.modelValue) {
                return c.name;
            }
        }
        return '';
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
        emit('update:modelValue', value);
    }
</script>