<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <footer class="footer">
    <div>
      <a
        class="link"
        href="https://github.com/COS301-SE-2022/Exploring-Self-Sovereign-Identity"
        target="_blank"
        rel="nofollow noopener noreferrer"
      >
        Code of Duty
      </a>
    </div>

    <div class="divider">|</div>
    <div>
      <a> MiDentity </a>
    </div>
  </footer>
</template>
<script lang="ts">
import { defineComponent } from 'vue'
export default defineComponent({
  data() {
    return {}
  },
  components: {},
  methods: {},
})
</script>
<script lang="ts" setup></script>

<style lang="scss" scoped>
@use 'src/styles/var';

.footer {
  display: flex;
  align-items: center;
  justify-content: center;
  height: var.$layout-footer-height;
  padding: 0.8rem 0;
  color: rgba(var.$color-text, 0.4);
  font-weight: bold;
  font-size: 0.8rem;

  .divider {
    padding: 0 1rem;
  }

  .locale {
    cursor: pointer;
  }

  .link,
  .locale {
    transition: color 0.2s;

    &:hover {
      color: var.$color-text;
    }
  }
}
</style>
