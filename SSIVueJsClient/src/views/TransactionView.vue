<script lang="ts">
import { ref } from "vue";

export default {
  setup() {
    const value4 = ref(true);
    return { value4 };
  },
  method: {
    goto() {
      this.$router.push("/");
    },
  },
};
</script>

<template>
  <div>
    <el-card>
      <el-switch
        v-model="value4"
        class="ml-2"
        inline-prompt
        active-color="#13ce66"
        inactive-color="#ff4949"
        active-text="Y"
        inactive-text="N"
        @change="$emit('toggle', 2)"
      />
    </el-card>
  </div>
</template>
