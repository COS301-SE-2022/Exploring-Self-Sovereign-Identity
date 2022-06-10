<script lang="ts">
import { Contract } from "@/models/entity/Contract";
import { defineComponent, ref } from "vue";
import BackNav from "../components/Nav/BackNav.vue";
import { mapState } from "pinia";
import { PendingTransactionsStore } from "@/stores/PendingTransactionStore";
export default defineComponent({
  setup() {
    const attributes = ref([]);
    return { attributes };
  },
  props: ["index"],
  data() {
    return {
      contract: new Contract([]),
    };
  },
  method: {
    sendData() {
      console.log;
    },
  },
  computed: {
    ...mapState(PendingTransactionsStore, ["getPendingTransactions"]),
  },
  mounted() {
    this.contract = this.getPendingTransactions.at(this.index)?.getContract();
    if (this.contract != undefined) {
      for (var el = 0; el < this.contract.getAttributes().length; el++) {
        this.attributes.push(this.contract?.getAttributes().at(el)?.getName());
      }
    }
  },
  components: { BackNav },
});
</script>

<template>
  <div>
    <el-card v-for="(a, index) in contract.getAttributes()" :key="a.getName()">
      <span>{{ a.getName() }}</span>
      <el-switch
        v-model="attributes[index]"
        class="switch"
        inline-prompt
        active-color="#13ce66"
        inactive-color="#ff4949"
        active-text="Y"
        inactive-text="N"
        inactive-value=""
        :active-value="a.getName()"
      />
    </el-card>
  </div>
  <div class="submit">
    <el-button @click="sendData" plain type="primary" round>Request</el-button>
  </div>

  <BackNav page="Transaction" />
</template>

<style lang="scss">
.switch {
  float: right;
}

.submit {
  margin-top: 15vh;
  width: 100vw;
  text-align: center;
  button {
    margin-right: auto;
    margin-left: auto;
    // color: whitesmoke;
    // background-color: black;
  }
</style>
