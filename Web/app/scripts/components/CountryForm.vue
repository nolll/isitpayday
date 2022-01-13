<template>
    <div>
        <h3>Country</h3>
        <div class="country-info">
            <p v-show="isFormVisible">
                <select :value="modelValue" v-on:input="updateValue" >
                    <option v-for="c in countries" :value="c.id" :key="c.id">{{c.name}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!isFormVisible">
                <span v-text="countryName"></span>
                <a href="#" @click.prevent="open">Change</a>
            </p>
        </div>
    </div>
</template>

<script setup lang="ts">
    import { Country } from '@/types/Country';
    import { computed, ref } from 'vue';
    
    const props = defineProps<{
        modelValue: string,
        countries: Country[]
    }>();

    const emit = defineEmits(['update:modelValue']);

    const isFormVisible = ref(false);

    const countryName = computed(() => {
        for (const c of props.countries) {
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