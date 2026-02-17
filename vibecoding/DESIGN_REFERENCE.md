# Color & Design Reference Guide

## Theme Color Specifications

### Light Theme (Default)

```
BACKGROUNDS:
├── Primary (Main Surface)   → #ffffff         (white)
├── Secondary                → #f8f9fa         (very light gray)
├── Tertiary (Elevated)      → #f0f2f5         (light gray)
└── Card Surface             → #ffffff         (white with border)

TEXT:
├── Primary (Body Text)      → #1a1a1a         (near black, high contrast)
├── Secondary (Descriptions) → #666666         (medium gray)
└── Tertiary (Hints/Labels)  → #999999         (light gray)

BORDERS:
├── Light Border             → #e0e0e0         (subtle)
└── Medium Border            → #d0d0d0         (emphasized)

SEMANTICS:
├── Bar (Normal)             → #3b82f6         (blue)
├── Compare Highlight        → #fbbf24         (amber)
├── Swap Highlight           → #ef4444         (red)
└── Sorted Elements          → #10b981         (green)

STATUS:
├── Success                  → #10b981         (green)
├── Warning                  → #f59e0b         (amber)
└── Error                    → #ef4444         (red)
```

### Dark Theme

```
BACKGROUNDS:
├── Primary Surface          → #0f172a         (deep navy)
├── Secondary                → #1a1f3a         (navy)
├── Tertiary (Elevated)      → #252d45         (medium navy)
└── Card Surface             → #1e2940         (navy with border)

TEXT:
├── Primary (Body Text)      → #f0f4ff         (white-blue, high contrast)
├── Secondary (Descriptions) → #c5d3e0         (light gray-blue)
└── Tertiary (Hints/Labels)  → #8899bb         (muted blue-gray)

BORDERS:
├── Light Border             → #334455         (subtle)
└── Medium Border            → #445566         (emphasized)

SEMANTICS:
├── Bar (Normal)             → #60a5fa         (brighter blue for dark bg)
├── Compare Highlight        → #fcd34d         (brighter amber)
├── Swap Highlight           → #f87171         (brighter red)
└── Sorted Elements          → #34d399         (brighter green)
```

---

## Typography Scale

```
Headlines:
├── h1 (App Title)           → 1.75rem (28px), weight 600
├── h2 (Section Header)      → 1.125rem (18px), weight 600
├── h3 (Card Title)          → 1rem (16px), weight 600
└── h4 (Minor Header)        → 0.95rem (15px), weight 600

Body:
├── Body Text (Default)      → 1rem (16px), weight 400
├── Body Small               → 0.95rem (15px), weight 400
├── Label/Hint               → 0.875rem (14px), weight 500
├── Caption                  → 0.8rem (13px), weight 400
└── Tiny/Meta                → 0.75rem (12px), weight 500

Monospace (Fira Code):
├── Code Display             → 0.95rem (15px), weight 400
├── Value Display            → varies, weight 600
└── Code Block               → 0.9rem (14px), weight 400
```

---

## Component Specifications

### Buttons

**Primary Button (Run Sort)**
- Height: 48px (1rem padding top/bottom)
- Width: 100% (in sidebar)
- Color: #3b82f6 (blue) → #2563eb (hover)
- Text Color: white
- Font Weight: 600
- Border Radius: 8px
- Shadow: 0 2px 8px rgba(59, 130, 246, 0.3)
- Hover State: +4px shadow, -2px translate, darker color

**Secondary Button (Clear, Presets)**
- Height: 36px (0.6rem padding)
- Color: var(--bg-secondary)
- Text Color: var(--text-primary)
- Border: 1px solid var(--border-light)

**Outline Button (Copy)**
- Height: 32px (0.5rem padding)
- Color: transparent background
- Text Color: var(--color-accent)
- Border: 1px solid var(--border-light)

### Input Elements

**Textarea (Array Input)**
- Height: 100px minimum
- Padding: 0.875rem
- Border: 1px solid var(--border-light)
- Border-Radius: 8px
- Focus: Box-shadow 0 0 0 3px rgba(59, 130, 246, 0.1), wider border

**Dropdown Select**
- Height: auto (min 44px touch target)
- Padding: 0.75rem
- Font: Inter, 1rem
- Border-Radius: 8px
- Custom styled in both themes

### Checkbox**
- Size: 20x20px
- Accent Color: var(--color-accent)
- Cursor: pointer

### Range Slider**
- Height: 6px track, 18px thumb
- Track Color: var(--bg-tertiary)
- Thumb Color: var(--color-accent)
- Thumb Shadow: 0 2px 6px rgba(59, 130, 246, 0.3)

---

## Spacing System (8px Grid)

```
xs  →  0.25rem (4px)    - micro spacing
sm  →  0.5rem  (8px)    - small padding
md  →  1rem    (16px)   - standard padding
lg  →  1.5rem  (24px)   - section spacing
xl  →  2rem    (32px)   - major layout spacing

Examples:
- Card Padding      → 1.5rem (md)
- Section Gap       → 1.5rem (md)
- Layout Gap        → 2rem (xl)
- Button Padding H  → 1.5rem
- Button Padding V  → 0.75rem
```

---

## Responsive Breakpoints

```
Desktop:   > 1024px     (2-column: 320px sidebar + content)
Tablet:    768-1024px   (2-column: 280px sidebar + content)
Mobile:    < 768px      (1-column: full-width stacked)
Small Mob: < 480px      (compact: reduced padding/margins)
```

---

## Canvas Visualization

**Canvas Size**:
- Width: 100% of parent container
- Height: Auto (responsive), default 300px
- Aspect Ratio: Maintains on resize

**Color Scheme** (matches semantic colors):
- Normal Bar:     var(--color-bar)     - Blue
- Comparing:      var(--color-compare) - Amber
- Swapping:       var(--color-swap)    - Red
- Sorted:         var(--color-sorted)  - Green

**Animation**:
- Speed Range: 1x (slowest) to 200x (fastest)
- Delay Calculation: `Math.max(1, 201 - speedValue)` ms per frame
- Frame Rate: ~60fps (browser frame sync)

---

## Metric Cards

**Card Layout**:
- Min Width: 150px
- Padding: 1.25rem
- Border: 1px solid var(--border-light)
- Border-Radius: 12px

**Content Structure**:
```
Label:       0.8rem, uppercase, letter-spacing 0.5px, color tertiary
Value:       1.75rem, font 700, monospace, color accent
Unit:        0.75rem, color tertiary
```

**Interactive States**:
- Default: Standard appearance
- Hover: Border to accent color, slight lift (-2px), shadow added
- Active: Scale down slightly (scale 0.98)

---

## Icon & Theme Toggle

**Theme Icon Button**:
- Size: 44x44px
- Border: 2px solid var(--border-light)
- Border-Radius: 8px
- Font-Size: 1.5rem

**State**:
- Light Theme:     Icon = 🌙 (moon)
- Dark Theme:      Icon = ☀️ (sun)

**Transitions**:
- All properties: 300ms cubic-bezier(0.4, 0, 0.2, 1)
- Hover: Border color → accent, background → secondary
- Active: Scale 0.95x

---

## Scrollbar Styling

**Light Theme**:
- Track: var(--bg-tertiary)
- Thumb: var(--border-medium)
- Thumb Hover: var(--color-accent)
- Width: 8px
- Border-Radius: 4px

**Dark Theme**:
- Same structure, colors adaptive via CSS vars

---

## Accessibility Targets

**Minimum Touch Target**: 44x44px
- Buttons: Meet or exceed
- Form inputs: Meet or exceed
- Links: Adequate hit area

**Contrast Ratios** (WCAG AA):
- Text on Background: 4.5:1 minimum
- Graphics on Background: 3:1 minimum
- Both themes verified

**Focus Indicators**:
- Outline: 2px solid accent color
- Offset: 2px from element
- Visible on all interactive elements

---

## Theme Switch Transition

**Timing**: 300ms
**Easing**: cubic-bezier(0.4, 0, 0.2, 1)
**Properties**: All (backdrop colors, text colors, borders, shadows)

**No Flash**:
- Theme applied before render
- CSS transition handles color changes
- localStorage persistence prevents data loss

---

## Usage Examples

### Light Theme Palette
```
Main Card Background:    #ffffff
Text:                    #1a1a1a
Secondary Text:          #666666
Input Field Background:  #f8f9fa
Button Primary:          #3b82f6
Button Hover:            #2563eb
Compare Highlight:       #fbbf24
Swap Highlight:          #ef4444
Sorted Color:            #10b981
```

### Dark Theme Palette
```
Main Card Background:    #1e2940
Text:                    #f0f4ff
Secondary Text:          #c5d3e0
Input Field Background:  #1a1f3a
Button Primary:          #3b82f6
Button Hover:            #60a5fa
Compare Highlight:       #fcd34d
Swap Highlight:          #f87171
Sorted Color:            #34d399
```

---

## Font Stack Selection

**Primary UI (Inter)**
```css
font-family: 'Inter', -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, 'Helvetica Neue', sans-serif;
```
Fallback: System fonts on unsupported browsers

**Data/Code (Fira Code)**
```css
font-family: 'Fira Code', monospace;
```
Fallback: System monospace fonts

---

## Quick Reference Hex Codes

| Element | Light | Dark |
|---------|-------|------|
| Primary BG | `#ffffff` | `#0f172a` |
| Text Primary | `#1a1a1a` | `#f0f4ff` |
| Bar Color | `#3b82f6` | `#60a5fa` |
| Compare | `#fbbf24` | `#fcd34d` |
| Swap | `#ef4444` | `#f87171` |
| Sorted | `#10b981` | `#34d399` |
| Border | `#e0e0e0` | `#334455` |
| Input BG | `#f8f9fa` | `#1a1f3a` |
