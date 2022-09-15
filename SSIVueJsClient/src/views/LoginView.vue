<script lang="ts">
import { defineComponent } from "vue";
import "@passageidentity/passage-elements/passage-auth";
export default defineComponent({
  data() {
    return {};
  },
  components: {},
  methods: {
    // route() {
    //   this.$router.push({ path: "/home" });
    // },
  },
  setup() {
    const appid = "Q17Gza9k49k1ieI15r73xaQf";
    return { appid };
  },
});
</script>

<template>
  <!-- <div class="heading"><IconHeading /></div> -->

  <!-- *Passage component -->
  <div class="authContainer">
    <passage-auth :app-id="appid"></passage-auth>
  </div>

  <!-- *! will need to replace this biometric with passage once it is setup -->
  <!-- <div class="Biometric">
    <div @click="route">
      <IconButtonNoBG><IconBiometric /></IconButtonNoBG>
    </div>
  </div> -->
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
</template>

<style lang="scss">
// @import "@material/button/styles";

.heading {
  display: block;
  margin-left: auto;
  margin-right: auto;
  top: 10em;
  width: 100%;
  text-align: center;
  svg {
    width: 80%;
    height: auto;
    backdrop-filter: grayscale(20%);
    padding: 0.2em;
    border-radius: 5em;
    background-size: 1em;
    border: 0.1em solid rgba(0, 0, 0, 0);
  }
}

.Biometric {
  display: block;
  bottom: 4em;
  position: fixed;
  width: 100%;
  div {
    height: auto;
    width: 100%;
    text-align: center;
  }
  button {
    width: 25%;
    height: auto;
  }
}

@keyframes move {
  100% {
    transform: translate3d(0, 0, 1px) rotate(360deg);
  }
}

.background {
  position: fixed;
  width: 100vw;
  height: 100vh;
  top: 0;
  left: 0;
  background: #3e1e68;
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

.background span:nth-child(0) {
  color: #583c87;
  top: 23%;
  left: 25%;
  animation-duration: 54s;
  animation-delay: -30s;
  transform-origin: -19vw -10vh;
  box-shadow: 40vmin 0 5.598974508467605vmin currentColor;
}
.background span:nth-child(1) {
  color: #ffacac;
  top: 88%;
  left: 91%;
  animation-duration: 46s;
  animation-delay: -50s;
  transform-origin: 0vw 24vh;
  box-shadow: -40vmin 0 5.263983190793257vmin currentColor;
}
.background span:nth-child(2) {
  color: #e45a84;
  top: 55%;
  left: 49%;
  animation-duration: 37s;
  animation-delay: -7s;
  transform-origin: -3vw -4vh;
  box-shadow: -40vmin 0 5.592051204992487vmin currentColor;
}
.background span:nth-child(3) {
  color: #583c87;
  top: 5%;
  left: 38%;
  animation-duration: 44s;
  animation-delay: -21s;
  transform-origin: 2vw -24vh;
  box-shadow: 40vmin 0 5.8290976200233615vmin currentColor;
}
.background span:nth-child(4) {
  color: #ffacac;
  top: 30%;
  left: 45%;
  animation-duration: 24s;
  animation-delay: -22s;
  transform-origin: -16vw -6vh;
  box-shadow: -40vmin 0 5.32809087068241vmin currentColor;
}
.background span:nth-child(5) {
  color: #ffacac;
  top: 50%;
  left: 18%;
  animation-duration: 37s;
  animation-delay: -29s;
  transform-origin: 6vw -3vh;
  box-shadow: 40vmin 0 5.115313724802291vmin currentColor;
}
.background span:nth-child(6) {
  color: #ffacac;
  top: 36%;
  left: 62%;
  animation-duration: 24s;
  animation-delay: -17s;
  transform-origin: 7vw -13vh;
  box-shadow: 40vmin 0 5.317343021415983vmin currentColor;
}
.background span:nth-child(7) {
  color: #e45a84;
  top: 83%;
  left: 89%;
  animation-duration: 8s;
  animation-delay: -10s;
  transform-origin: 18vw 14vh;
  box-shadow: -40vmin 0 5.922243935812906vmin currentColor;
}
.background span:nth-child(8) {
  color: #ffacac;
  top: 51%;
  left: 10%;
  animation-duration: 48s;
  animation-delay: -1s;
  transform-origin: -4vw -5vh;
  box-shadow: -40vmin 0 5.213803086356414vmin currentColor;
}
.background span:nth-child(9) {
  color: #ffacac;
  top: 49%;
  left: 86%;
  animation-duration: 16s;
  animation-delay: -10s;
  transform-origin: -13vw -24vh;
  box-shadow: -40vmin 0 5.509871317474628vmin currentColor;
}
.background span:nth-child(10) {
  color: #583c87;
  top: 86%;
  left: 18%;
  animation-duration: 15s;
  animation-delay: -12s;
  transform-origin: -21vw -14vh;
  box-shadow: -40vmin 0 5.5478777439627205vmin currentColor;
}
.background span:nth-child(11) {
  color: #e45a84;
  top: 23%;
  left: 57%;
  animation-duration: 39s;
  animation-delay: -16s;
  transform-origin: -5vw 10vh;
  box-shadow: -40vmin 0 5.30551066364496vmin currentColor;
}
.background span:nth-child(12) {
  color: #e45a84;
  top: 13%;
  left: 44%;
  animation-duration: 52s;
  animation-delay: -6s;
  transform-origin: 15vw -24vh;
  box-shadow: -40vmin 0 5.901368369788511vmin currentColor;
}
.background span:nth-child(13) {
  color: #e45a84;
  top: 90%;
  left: 30%;
  animation-duration: 8s;
  animation-delay: -28s;
  transform-origin: -14vw -1vh;
  box-shadow: 40vmin 0 5.630897136301258vmin currentColor;
}
.background span:nth-child(14) {
  color: #ffacac;
  top: 39%;
  left: 29%;
  animation-duration: 19s;
  animation-delay: -9s;
  transform-origin: -21vw 22vh;
  box-shadow: -40vmin 0 5.402001402557588vmin currentColor;
}
.background span:nth-child(15) {
  color: #583c87;
  top: 20%;
  left: 70%;
  animation-duration: 19s;
  animation-delay: -5s;
  transform-origin: 8vw -7vh;
  box-shadow: 40vmin 0 5.512764565124262vmin currentColor;
}
.background span:nth-child(16) {
  color: #583c87;
  top: 40%;
  left: 99%;
  animation-duration: 21s;
  animation-delay: -35s;
  transform-origin: 3vw -10vh;
  box-shadow: -40vmin 0 5.064864141901173vmin currentColor;
}
.background span:nth-child(17) {
  color: #583c87;
  top: 79%;
  left: 88%;
  animation-duration: 49s;
  animation-delay: -13s;
  transform-origin: -21vw -14vh;
  box-shadow: -40vmin 0 5.492688002056775vmin currentColor;
}
.background span:nth-child(18) {
  color: #583c87;
  top: 7%;
  left: 33%;
  animation-duration: 15s;
  animation-delay: -12s;
  transform-origin: 14vw 24vh;
  box-shadow: 40vmin 0 5.971730767035624vmin currentColor;
}
.background span:nth-child(19) {
  color: #e45a84;
  top: 98%;
  left: 93%;
  animation-duration: 53s;
  animation-delay: -40s;
  transform-origin: 20vw 19vh;
  box-shadow: -40vmin 0 5.316958477212835vmin currentColor;
}
</style>
