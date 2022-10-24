<template>
  <div v-if="isReady">
    <p class="message">
      <span>{{ message }}</span>
    </p>
    <p class="next-payday" v-if="!isPayday">{{ nextPaydayMessage }}</p>
    <p class="error" v-if="hasError">
      <span>{{ error }}</span>
    </p>
    <div class="settings">
      <h2>Settings</h2>
      <FrequencyForm v-model="frequency" :frequencies="frequencies" />
      <PaydayForm v-model="payday" :frequencyId="frequency" />
      <CountryForm v-model="country" :countries="countries" />
      <TimezoneForm v-model="timezone" :timezones="timezones" />
    </div>
    <p class="footer">{{ formattedLocalTime }}</p>
    <p class="contact">
      Bugs and suggestions: <a :href="mailtoUrl">{{ email }}</a>
    </p>
  </div>
</template>

<script setup lang="ts">
import dayjs from 'dayjs';
import CountryForm from './components/CountryForm.vue';
import TimezoneForm from './components/TimezoneForm.vue';
import FrequencyForm from './components/FrequencyForm.vue';
import PaydayForm from './components/PaydayForm.vue';
import { Country } from '@/types/Country';
import { Frequency } from '@/types/Frequency';
import { Timezone } from '@/types/Timezone';
import ajax from './ajax';
import urls from './urls';
import defaults from './defaults';
import storage from './storage';
import frequencyTypes from './frequencyTypes';
import advancedFormat from 'dayjs/plugin/advancedFormat';
import { computed, onMounted, ref, watch } from 'vue';
import { def } from '@vue/shared';

dayjs.extend(advancedFormat);

const error = ref('');
const isOptionsReady = ref(false);
const isPaydayReady = ref(false);
const isPayday = ref(false);
const nextPayday = ref<Date | null>(null);
const localTime = ref('');
const payday = ref(defaults.payday);
const timezone = ref(defaults.getDefaultTimezone());
const frequency = ref(defaults.frequency);
const country = ref(defaults.country);
const countries = ref<Country[]>([]);
const timezones = ref<Timezone[]>([]);
const frequencies = ref<Frequency[]>([]);
const email = ref('info@isitpayday.com');

const isReady = computed(() => {
  return isPaydayReady.value && isOptionsReady.value;
});

const message = computed(() => {
  if (error.value) return 'Error';
  return isPayday.value ? 'YES!!1!' : 'No =(';
});

const nextPaydayMessage = computed(() => {
  if (nextPayday.value === null) return '';

  var formattedDate = dayjs(nextPayday.value).format('MMM D');
  return `Next payday is ${formattedDate}`;
});

const formattedLocalTime = computed(() => {
  if (localTime.value) return dayjs(localTime.value).format('MMM D YYYY, HH:mm:ss');
  return '';
});

const hasError = computed(() => {
  return !!error.value;
});

const mailtoUrl = computed(() => {
  return `mailto:${email.value}`;
});

watch(country, (oldVal, newVal) => {
  storage.saveCountry(country.value);
  loadPayday();
});

watch(frequency, (oldVal, newVal) => {
  storage.saveFrequency(frequency.value);
  payday.value = frequency.value === frequencyTypes.weekly ? defaults.weeklyPayday : defaults.monthlyPayday;
  storage.savePayday(payday.value);
  loadPayday();
});

watch(timezone, (oldVal, newVal) => {
  storage.saveTimezone(timezone.value);
  loadPayday();
});

watch(payday, (oldVal, newVal) => {
  storage.savePayday(payday.value);
  loadPayday();
});

watch(isOptionsReady, (oldVal, newVal) => {
  const isSavedTimezoneValid = !!timezones.value.find((tz) => {
    tz.id === timezone.value;
  });

  if (!isSavedTimezoneValid) {
    timezone.value = defaults.getDefaultTimezone();
    storage.saveTimezone(timezone.value);
  }
});

const loadSettings = () => {
  country.value = storage.getCountry();
  frequency.value = storage.getFrequency();
  timezone.value = storage.getTimezone();
  payday.value = storage.getPayday();
};

const loadPayday = async () => {
  try {
    const response = await ajax.get(paydayUrl.value);
    isPayday.value = response.data.isPayDay;
    nextPayday.value = new Date(response.data.nextPayDay);
    localTime.value = response.data.localTime;
    isPaydayReady.value = true;
  } catch (e) {
    error.value = 'Error loading payday';
  }
};

const loadOptions = async () => {
  try {
    const response = await ajax.get(urls.optionsUrl);
    countries.value = response.data.countries;
    timezones.value = response.data.timezones;
    frequencies.value = response.data.frequencies;
    isOptionsReady.value = true;
  } catch (e) {
    error.value = 'Error loading options';
  }
};

const paydayUrl = computed(() => {
  return frequency.value === frequencyTypes.weekly
    ? urls.weeklyUrl(payday.value, timezone.value, country.value)
    : urls.monthlyUrl(payday.value, timezone.value, country.value);
});

onMounted(() => {
  loadSettings();
  loadPayday();
  loadOptions();
});
</script>
