<script lang="ts">
import { defineComponent } from "vue";
export default defineComponent({
  props: ["foo"],
  data() {
    return { attributes: [] };
  },
  method: {
    toggle(name: string) {
      console.log(name);
    },
  },
});
</script>

<template>
  <div>
    <el-card v-for="(c, index) in contract.getAttributes()" :key="c.getName()">
      <span>{{ c.getName() }}</span>
      <el-switch
        v-model="c.getAttributes()[index]"
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
</template>
