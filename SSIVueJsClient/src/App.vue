<script setup lang="ts">
import { RouterView } from "vue-router";
import { NConfigProvider } from "naive-ui";
import { darkTheme } from "naive-ui";

/**
 * Use this for type hints under js file
 * @type import('naive-ui').GlobalThemeOverrides
 */
const themeOverrides = {
  common: {
    primaryColor: "#C197D2",
    primaryColorHover: "#613659",
    primaryColorPressed: "#613659",
  },
  return: {
    darkTheme,
  },
};
</script>

<template>
  <n-config-provider :theme-overrides="themeOverrides" :theme="darkTheme">
    <router-view v-slot="{ Component }">
      <transition name="fade">
        <n-message-provider>
          <component :is="Component" />
        </n-message-provider>
      </transition>
    </router-view>
    <div class="background">
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
    </div>
  </n-config-provider>
</template>

<style lang="scss">
.fade-enter-active {
  transition: all opacity 1s ease;
}
.fade-leave-active {
  transition: all opacity 1s ease;
}

.fade-enter-from {
  opacity: 0;
}
.fade-enter-to {
  opacity: 1;
}
.fade-leave-from {
  opacity: 1;
}
.fade-leave-to {
  opacity: 0;
}
.background {
  position: fixed;
  width: 100vw;
  height: 100vh;
  top: 0;
  left: 0;
  // background: #ffffff;
  overflow: hidden;
  z-index: -1;
}

.background span {
  width: 20vmin;
  height: 20vmin;
  border-radius: 20vmin;
  backface-visibility: hidden;
  position: absolute;
  animation: move;
  animation-duration: 45;
  animation-timing-function: linear;
  animation-iteration-count: infinite;
}

@keyframes move {
  100% {
    transform: translate3d(0, 0, 1px) rotate(360deg);
  }
}

.background span:nth-child(0) {
  color: #c197d2;
  top: 12%;
  left: 38%;
  animation-duration: 39s;
  animation-delay: -23s;
  transform-origin: -13vw -6vh;
  box-shadow: -40vmin 0 5.641906387991167vmin currentColor;
}
.background span:nth-child(1) {
  color: #d3b1c2;
  top: 61%;
  left: 16%;
  animation-duration: 24s;
  animation-delay: -43s;
  transform-origin: 2vw 17vh;
  box-shadow: -40vmin 0 5.21768313481472vmin currentColor;
}
.background span:nth-child(2) {
  color: #c197d2;
  top: 43%;
  left: 10%;
  animation-duration: 45s;
  animation-delay: -47s;
  transform-origin: -20vw -3vh;
  box-shadow: 40vmin 0 5.860883208486514vmin currentColor;
}
.background span:nth-child(3) {
  color: #613659;
  top: 65%;
  left: 69%;
  animation-duration: 10s;
  animation-delay: -48s;
  transform-origin: 6vw 2vh;
  box-shadow: -40vmin 0 5.255696744502337vmin currentColor;
}
.background span:nth-child(4) {
  color: #c197d2;
  top: 43%;
  left: 55%;
  animation-duration: 18s;
  animation-delay: -46s;
  transform-origin: 23vw 6vh;
  box-shadow: -40vmin 0 5.427797587782514vmin currentColor;
}
.background span:nth-child(5) {
  color: #613659;
  top: 68%;
  left: 56%;
  animation-duration: 47s;
  animation-delay: -22s;
  transform-origin: -22vw 23vh;
  box-shadow: 40vmin 0 5.889174563699299vmin currentColor;
}
.background span:nth-child(6) {
  color: #d3b1c2;
  top: 97%;
  left: 58%;
  animation-duration: 7s;
  animation-delay: -8s;
  transform-origin: 16vw 7vh;
  box-shadow: -40vmin 0 5.400666124036952vmin currentColor;
}
.background span:nth-child(7) {
  color: #613659;
  top: 30%;
  left: 86%;
  animation-duration: 14s;
  animation-delay: -32s;
  transform-origin: 10vw -5vh;
  box-shadow: 40vmin 0 5.048694697289397vmin currentColor;
}
.background span:nth-child(8) {
  color: #c197d2;
  top: 8%;
  left: 53%;
  animation-duration: 21s;
  animation-delay: -12s;
  transform-origin: 20vw -4vh;
  box-shadow: -40vmin 0 5.687982806691891vmin currentColor;
}
.background span:nth-child(9) {
  color: #c197d2;
  top: 56%;
  left: 76%;
  animation-duration: 25s;
  animation-delay: -1s;
  transform-origin: -14vw -18vh;
  box-shadow: -40vmin 0 5.292837684293237vmin currentColor;
}
.background span:nth-child(10) {
  color: #d3b1c2;
  top: 30%;
  left: 82%;
  animation-duration: 23s;
  animation-delay: -14s;
  transform-origin: -22vw -23vh;
  box-shadow: -40vmin 0 5.629809962367889vmin currentColor;
}
.background span:nth-child(11) {
  color: #c197d2;
  top: 97%;
  left: 94%;
  animation-duration: 43s;
  animation-delay: -25s;
  transform-origin: 12vw -7vh;
  box-shadow: -40vmin 0 5.414017515907672vmin currentColor;
}
.background span:nth-child(12) {
  color: #c197d2;
  top: 5%;
  left: 83%;
  animation-duration: 37s;
  animation-delay: -32s;
  transform-origin: -14vw 0vh;
  box-shadow: -40vmin 0 5.587261935904543vmin currentColor;
}
.background span:nth-child(13) {
  color: #d3b1c2;
  top: 85%;
  left: 94%;
  animation-duration: 53s;
  animation-delay: -23s;
  transform-origin: -16vw -21vh;
  box-shadow: -40vmin 0 5.184845749122784vmin currentColor;
}
.background span:nth-child(14) {
  color: #c197d2;
  top: 81%;
  left: 74%;
  animation-duration: 26s;
  animation-delay: -25s;
  transform-origin: -18vw -11vh;
  box-shadow: 40vmin 0 5.48934739379526vmin currentColor;
}
.background span:nth-child(15) {
  color: #c197d2;
  top: 41%;
  left: 70%;
  animation-duration: 19s;
  animation-delay: -11s;
  transform-origin: 23vw 3vh;
  box-shadow: 40vmin 0 5.494332920914466vmin currentColor;
}
.background span:nth-child(16) {
  color: #d3b1c2;
  top: 10%;
  left: 13%;
  animation-duration: 32s;
  animation-delay: -25s;
  transform-origin: -22vw -20vh;
  box-shadow: -40vmin 0 5.305543035740362vmin currentColor;
}
.background span:nth-child(17) {
  color: #c197d2;
  top: 17%;
  left: 41%;
  animation-duration: 25s;
  animation-delay: -30s;
  transform-origin: 15vw -10vh;
  box-shadow: 40vmin 0 5.807916465481354vmin currentColor;
}
.background span:nth-child(18) {
  color: #c197d2;
  top: 4%;
  left: 4%;
  animation-duration: 17s;
  animation-delay: -29s;
  transform-origin: 14vw -22vh;
  box-shadow: -40vmin 0 5.578044457602442vmin currentColor;
}
.background span:nth-child(19) {
  color: #613659;
  top: 84%;
  left: 88%;
  animation-duration: 16s;
  animation-delay: -8s;
  transform-origin: -15vw 5vh;
  box-shadow: 40vmin 0 5.99443952852025vmin currentColor;
}
</style>
