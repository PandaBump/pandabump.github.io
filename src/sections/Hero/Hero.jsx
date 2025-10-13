import styles from "./HeroStyles.module.css";
import heroImg from "../../assets/hero-img.png";
import sun from "../../assets/sun.svg";
import moon from "../../assets/moon.svg";
import twitterLight from "../../assets/twitter-light.svg";
import twitterDark from "../../assets/twitter-dark.svg";
import githubLight from "../../assets/github-light.svg";
import githubDark from "../../assets/github-dark.svg";
import linkedinLight from "../../assets/linkedin-light.svg";
import linkedinDark from "../../assets/linkedin-dark.svg";
import CV from "../../assets/cv.pdf";
import { useTheme } from "../../common/ThemeContext.jsx";

function Hero() {
  const { theme, toggleTheme } = useTheme();
  const themeIcon = theme === 'light' ? sun : moon;
  const twitterIcon = theme === 'light' ? twitterLight : twitterDark;
  const githubIcon = theme === 'light' ? githubLight : githubDark;
  const linkedinIcon = theme === 'light' ? linkedinLight : linkedinDark;
  return (
    <section id="hero" className={styles.container}>
      <div className={styles.colorModeContainer}>
        <img
          className={styles.hero}
          src={heroImg}
          alt="Profile picture of me.  I've never looked cuter."
        />
        <img
          className={styles.colorMode}
          src={themeIcon}
          alt="Color mode icon"
          onClick={toggleTheme}
        />
      </div>
      <div className={styles.into}>
        <h1>
          Keith
          <br />
          Stokes
        </h1>
        <h2>Software Engineer</h2>
        <span>
          <a href="https://twitter.com/Keith_SWE" target="_blank">
            <img src={twitterIcon} alt="Twitter icon"></img>
          </a>
          <a href="https://github.com/PandaBump" target="_blank">
            <img src={githubIcon} alt="Github icon"></img>
          </a>
          <a href="https://linkedin.com/in/keith-stokes-swe/" target="_blank">
            <img src={linkedinIcon} alt="Linkedin icon"></img>
          </a>
        </span>
        <p className={styles.description}>
          Passionately devoted to emphasizing the art in
          <br />
          web development and programming!
        </p>
        <a href={CV} download>
          <button className="hover">Resume</button>
        </a>
      </div>
    </section>
  );
}

export default Hero;
