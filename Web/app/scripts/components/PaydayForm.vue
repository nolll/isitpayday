<template>
    <div>
        <h3>Payday</h3>
        <div class="payday-info">
            <p v-show="isFormVisible">
                <select :value="value" v-on:input="updateValue">
                    <option v-for="p in paydays" :value="p.id" :key="p.id">{{p.name}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!isFormVisible">
                {{paydayName}}
                <a href="#" @click.prevent="open">Change</a>
            </p>
        </div>
    </div>
</template>

<script setup lang="ts">
    import frequencies from '@/frequencies';
    import nthFormatter from '@/nth-formatter';
    import weekdays from '@/weekdays';
    import { Payday } from '@/types/Payday';
    import { computed, ref } from 'vue';

    const props = defineProps<{
        value: number,
        frequencyId: string
    }>();

    const emit = defineEmits(['input']);

    const isFormVisible = ref(false);

    const paydayName = computed(() => {
        return format(props.frequencyId, props.value);
    });

    const paydays = computed(() => {
        return getPayDays(props.frequencyId);
    });

    const getPayDays = (frequencyId: string) => {
        if (frequencyId === frequencies.weekly)
            return getWeeklyPaydays(frequencyId);
        return getMonthlyPaydays(frequencyId);
    }

    const getWeeklyPaydays = (frequencyId: string) => {
        return getPaydaysArray(frequencyId, 7);
    }

    const getMonthlyPaydays = (frequencyId: string) => {
        return getPaydaysArray(frequencyId, 31);
    }

    const getPaydaysArray = (frequencyId: string, upperBound: number): Payday[] => {
        const paydays: Payday[] = [];

        for (let i = 1; i <= upperBound; i++) {
            paydays.push({ id: i, name: format(frequencyId, i) });
        }
        return paydays;
    }

    const format = (frequencyId: string, payday: number) => {
        if (frequencyId === frequencies.weekly)
            return weekdays.getName(payday);
        return nthFormatter.format(payday);
    }

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
