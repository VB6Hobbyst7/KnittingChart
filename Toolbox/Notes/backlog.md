# Knitting Chart Backlog

## SCRUM notes

### Product Goal

Create a tool to allow knitters to create and interact with graphical knitting charts

### Personas

- Knitters
- Pattern Creators
- Developer
- Product Owner

### Epics

- As a knitter, I want to input pre-written pattern text and receive a graphical chart
- As a product owners, I want to ensure code is self-documented
- As product owner, I want to implement appropriate test coverage

### User Stories

- As a knitter, I want to open knitting charts that have been created previously
- As a knitter, I want to copy text of a pattern into an input field
- As a knitter, I want to upload a text file containing pattern text

## Technical Notes

### General Order of Operations

1. Full pattern text
2. Rows of text
3. Stitch text
4. Stitch object
5. Row object
6. Pattern object

### Object properties

#### Stitch

- Name
- Formation Instructions
  -Icon image
- Stitch count change (increase, decrease, etc)
- Stitch span (e.g C6F spans six stitches)

#### Row

- List of stitches

#### Pattern

- List of rows for base pattern
- Materials
- Needle sizes
- Preamble (notes, etc)
- Images
- Author
