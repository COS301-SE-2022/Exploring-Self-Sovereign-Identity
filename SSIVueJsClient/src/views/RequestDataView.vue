<script lang="ts">
import { defineComponent } from "vue";
import BackNav from "../components/Nav/BackNav.vue";
import { transactionsStore } from "@/stores/transactions";

export default defineComponent({
  setup() {
    const transactions = transactionsStore();
    return { transactions };
  },
  data() {},
  methods: {},
  components: { BackNav },
});
</script>

<template>
  <n-collapse accordion arrow-placement="right">
    <n-collapse-item
      v-for="t in transactions.requests"
      :key="t.stamp.fromID"
      :name="t.stamp.fromID"
      :title="t.stamp.fromID"
    >
      <template #header-extra>{{ t.stamp.date }}</template>
      <n-input-group
        v-for="att in t.attributes"
        :key="att"
        data-test-id="attribute"
      >
        <n-input-group-label>{{ att }}</n-input-group-label>
        <n-input
          :key="att"
          :default-value="transactions.exists(att)"
          :disabled="!transactions.exists(att)"
        ></n-input>
      </n-input-group>
    </n-collapse-item>
  </n-collapse>
  <BackNav page="Request Data" />
</template>

<style lang="scss"></style>
