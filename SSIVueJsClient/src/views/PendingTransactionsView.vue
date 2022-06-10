<script lang="ts">
import BackNav from "../components/Nav/BackNav.vue";
import { mapState } from "pinia";
import { PendingTransactionsStore } from "@/stores/PendingTransactionStore";
import { defineComponent } from "vue";
export default defineComponent({
  components: { BackNav },
  computed: {
    ...mapState(PendingTransactionsStore, ["getPendingTransactions"]),
  },
  methods: {
    view(value: number) {
      this.$router.push({
        path: "/transaction?c=" + value,
      });
    },
  },
});
</script>

<template>
  <div>
    <el-card
      v-for="(t, index) in getPendingTransactions"
      :key="t.getFrom()"
      @click="view(index)"
    >
      <template #header>
        <span class="from"> {{ t.getFrom() }}</span>
      </template>
      <div>
        <el-tag
          class="ml-2"
          type="info"
          v-for="a in t.getContract().getAttributes()"
          :key="a.getName()"
          >{{ a.getName() }}</el-tag
        >
      </div>
    </el-card>
  </div>

  <BackNav />
</template>

<style lang="scss">
.from {
  font-weight: bold;
}
</style>
