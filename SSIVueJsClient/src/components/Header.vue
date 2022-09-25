<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <header class="header">
    <Logo />

    <div class="header-right">
      <a
        href="https://github.com/COS301-SE-2022/Exploring-Self-Sovereign-Identity"
        target="_blank"
        rel="nofollow noopener noreferrer"
      >
        <button type="button" class="github-button">
          <span class="text">Code of Duty</span>
        </button>
      </a>
    </div>
  </header>
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

<style lang="scss" scoped>
@use 'src/styles/var';

.header {
  display: flex;
  align-items: center;
  height: var.$layout-header-height;
  padding: 1rem 2rem;

  .site-title {
    margin-left: 1rem;
    font-weight: bold;
    font-size: 1.9rem;
    cursor: default;

    @media screen and (max-width: var.$screen-sm) {
      display: none;
    }
  }

  .header-right {
    margin-left: auto;

    .github-button {
      position: relative;
      z-index: 0;
      display: flex;
      align-items: center;
      justify-content: center;
      width: 9rem;
      height: 2.6rem;
      overflow: hidden;
      color: var.$color-text;
      font-weight: bold;
      font-size: 1.05rem;
      background-color: var.$color-dark;
      border-radius: 0.6rem;
      cursor: pointer;
      user-select: none;

      &:hover {
        background-color: darken(var.$color-dark, 3);
      }

      .text {
        margin-left: 0.5rem;
        letter-spacing: 0.03rem;
      }
    }
  }
}
</style>
