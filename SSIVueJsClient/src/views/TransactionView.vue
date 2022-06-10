<script lang="ts">
import { Attribute } from "@/models/entity/Attribute";
import { Contract } from "@/models/entity/Contract";
import { defineComponent } from "vue";
import BackNav from "../components/Nav/BackNav.vue";
export default defineComponent({
  setup() {
    const attributes: string[] = [];
    return { attributes };
  },
  props: {
    
    },
  },
  data() {
    return { contract: Contract };
  },
  method: {
    toggle(name: string) {
      console.log(name);
    },
  },
  mounted() {
    for (var el = 0; el < this.contract.getAttributes().length; el++) {
      this.attributes.push(this.contract?.getAttributes().at(el)?.getName());
    }
  },
  components: { BackNav },
});
</script>

<template>
  <div>
    <el-card v-for="a in contract.getAttributes()" :key="a.getName()">
      <span>{{ a.getName() }}</span>
      <el-switch
        v-model="attributes[attributes.indexOf(a.getName())]"
        class="ml-2"
        inline-prompt
        active-color="#13ce66"
        inactive-color="#ff4949"
        active-text="Y"
        inactive-text="N"
        :active-value="c.getName()"
        @change="$emit('toggle', 2)"
      />
    </el-card>
  </div>

  <BackNav page="Transaction" />
</template>
